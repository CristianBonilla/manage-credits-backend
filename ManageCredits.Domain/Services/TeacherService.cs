using System.Net;
using ManageCredits.Contracts.Exceptions;
using ManageCredits.Contracts.Services;
using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Entities.Details;
using ManageCredits.Domain.Helpers;
using ManageCredits.Infrastructure.Repositories.Interfaces;
using ManageCredits.Infrastructure.Repositories.StudentCredits.Interfaces;
using ManageCredits.Infrastructure.Repositories.StudentCredits.Interfaces.Details;

namespace ManageCredits.Domain.Services;

public class TeacherService(
  IStudentCreditsRepositoryContext context,
  ITeacherRepository teacherRepository,
  ITeacherDetailRepository teacherDetailRepository,
  IStudentRepository studentRepository,
  IStudentDetailRepository studentDetailRepository,
  ISubjectRepository subjectRepository,
  IClassRepository classRepository) : ITeacherService
{
  readonly IStudentCreditsRepositoryContext _context = context;
  readonly ITeacherRepository _teacherRepository = teacherRepository;
  readonly ITeacherDetailRepository _teacherDetailRepository = teacherDetailRepository;
  readonly IStudentRepository _studentRepository = studentRepository;
  readonly IStudentDetailRepository _studentDetailRepository = studentDetailRepository;
  readonly ISubjectRepository _subjectRepository = subjectRepository;
  readonly IClassRepository _classRepository = classRepository;

  public async Task<(TeacherEntity, IEnumerable<TeacherDetailEntity>)> AddTeacher(TeacherEntity teacher, params Guid[] subjectIDs)
  {
    teacher = _teacherRepository.Create(teacher);
    _ = await _context.SaveAsync();
    if (subjectIDs.Length == 0)
      throw new ServiceErrorException(HttpStatusCode.BadRequest, $"Teacher with document number \"{teacher.DocumentNumber}\" does not contain any linked subject");
    var teacherDetails = subjectIDs.SelectMany(subjectId => GetTeacherDetails(teacher.TeacherId, subjectId));
    teacherDetails = _teacherDetailRepository.CreateRange(teacherDetails);
    _ = await _context.SaveAsync();

    return (teacher, teacherDetails);
  }

  public async Task<ClassEntity> AddClass(Guid teacherId, ClassEntity classObj)
  {
    if (!_teacherRepository.Exists(teacher => teacher.TeacherId == teacherId))
      throw new ServiceErrorException(HttpStatusCode.NotFound, $"Teacher not found with related identifier \"{teacherId}\"");
    if (_classRepository.Exists(obj => obj.SubjectId == obj.SubjectId && obj.Name == classObj.Name))
      throw new ServiceErrorException(HttpStatusCode.BadRequest, $"Class \"{classObj.Name}\" is already linked to the subject");
    classObj = _classRepository.Create(classObj);
    _ = await _context.SaveAsync();
    var studentDetails = _studentRepository.GetAll()
      .Select(student => new StudentDetailEntity
      {
        TeacherDetailId = teacherId,
        StudentId = student.StudentId,
        ClassId = classObj.ClassId,
        Status = ClassStatus.Pending
      });
    _studentDetailRepository.CreateRange(studentDetails);
    _ = await _context.SaveAsync();

    return classObj;
  }

  public Task<TeacherEntity> GetTeacher(Guid teacherId)
  {
    TeacherEntity teacher = _teacherRepository.Find([teacherId]) ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"Teacher not found with related identifier \"{teacherId}\"");

    return Task.FromResult(teacher);
  }

  public IAsyncEnumerable<TeacherEntity> GetTeachers() => _teacherRepository.GetAll(teacher => teacher.OrderBy(order => order.Firstname).ThenBy(order => order.Lastname)).ToAsyncEnumerable();

  public IAsyncEnumerable<SubjectEntity> GetSubjectsByTeacherId(Guid teacherId)
    => _teacherDetailRepository.GetByFilter(
        detail => detail.TeacherId == teacherId,
        detail => detail.OrderBy(order => order.Subject.Name),
        detail => detail.Subject)
          .Select(detail => detail.Subject)
          .ToAsyncEnumerable();

  private IEnumerable<TeacherDetailEntity> GetTeacherDetails(Guid teacherId, Guid subjectId)
    => _subjectRepository.GetByFilter(subject => subject.SubjectId == subjectId)
        .Where(subject => !_teacherDetailRepository.Exists(detail => detail.TeacherId == teacherId && detail.SubjectId == subjectId))
        .Select(subject => new TeacherDetailEntity
        {
          TeacherId = teacherId,
          SubjectId = subjectId,
          TotalCredits = TeacherCommonValues.TOTAL_CREDITS,
          Subject = subject
        });
}

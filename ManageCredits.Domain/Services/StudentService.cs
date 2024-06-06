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

public class StudentService(
  IStudentCreditsRepositoryContext context,
  IStudentRepository studentRepository,
  IStudentDetailRepository studentDetailRepository,
  ITeacherRepository teacherRepository,
  ITeacherDetailRepository teacherDetailRepository,
  ISubjectRepository subjectRepository,
  IClassRepository classRepository) : IStudentService
{
  readonly IStudentCreditsRepositoryContext _context = context;
  readonly IStudentRepository _studentRepository = studentRepository;
  readonly IStudentDetailRepository _studentDetailRepository = studentDetailRepository;
  readonly ITeacherRepository _teacherRepository = teacherRepository;
  readonly ITeacherDetailRepository _teacherDetailRepository = teacherDetailRepository;
  readonly ISubjectRepository _subjectRepository = subjectRepository;
  readonly IClassRepository _classRepository = classRepository;

  public async Task<(StudentEntity, IEnumerable<StudentDetailEntity>)> AddStudent(StudentEntity student, params Guid[] subjectIDs)
  {
    student = _studentRepository.Create(student);
    _ = await _context.SaveAsync();
    var studentDetails = subjectIDs
      .Select(GetTeacherDetailIdBySubjectId)
      .SelectMany(detail => GetStudentDetails(student.StudentId, detail.SubjectId, detail.TeacherDetailId));
    studentDetails = _studentDetailRepository.CreateRange(studentDetails);
    _ = await _context.SaveAsync();

    return (student, studentDetails);
  }

  public async Task<StudentDetailEntity> StatusChange(Guid studentId, Guid classId, ClassStatus status)
  {
    StudentDetailEntity studentDetail = _studentDetailRepository.Find(detail => detail.StudentId == studentId && detail.ClassId == classId) ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"Student detail not found with related student identifier \"{studentId}\" and class identifier \"{classId}\"");
    studentDetail.Status = status;
    studentDetail = _studentDetailRepository.Update(studentDetail);
    _ = await _context.SaveAsync();

    return studentDetail;
  }

  public ValueTask<decimal> GetCreditsByClassId(Guid studentId, Guid classId)
  {
    var credits = ValueTask.FromResult(0.0M);
    StudentDetailEntity? studentDetail = _studentDetailRepository.Find(detail => detail.StudentId == studentId && detail.ClassId == classId);
    if (studentDetail is null)
      return credits;

    TeacherDetailEntity? teacherDetail = _teacherDetailRepository.Find(detail => detail.TeacherDetailId == studentDetail.TeacherDetailId);
    if (teacherDetail is null)
      return credits;

    credits = ValueTask.FromResult(studentDetail.Status switch
    {
      ClassStatus.Pending => 0,
      ClassStatus.InProgress => teacherDetail.TotalCredits / GetTotalClassesBySubjectId(teacherDetail.SubjectId) / 2,
      ClassStatus.Completed => teacherDetail.TotalCredits / GetTotalClassesBySubjectId(teacherDetail.SubjectId),
      _ => throw new ServiceErrorException(HttpStatusCode.BadGateway, $"Status \"{studentDetail.Status}\" not defined correctly")
    });

    return credits;
  }

  public ValueTask<decimal> GetCreditsByStudentId(Guid studentId)
  {
    var credits = _studentDetailRepository.GetByFilter(detail => detail.StudentId == studentId)
       .ToAsyncEnumerable()
       .SelectAwait(detail => GetCreditsByClassId(studentId, detail.ClassId))
       .SumAsync();

    return credits;
  }

  public IAsyncEnumerable<string> GetStudentNamesByClassId(Guid classId, Guid exceptStudentId)
   => _studentDetailRepository.GetByFilter(
        detail => detail.StudentId != exceptStudentId && detail.ClassId == classId,
        detail => detail.OrderBy(order => order.Student.Firstname).ThenBy(order => order.Student.Lastname),
        detail => detail.Student)
          .Select(detail => $"{detail.Student.Firstname} {detail.Student.Lastname}")
          .ToAsyncEnumerable();

  public async IAsyncEnumerable<(TeacherEntity, StudentEntity, SubjectEntity, ClassStatus, decimal)> GetStudents()
  {
    var teacherDetails = _teacherDetailRepository.GetAll().ToAsyncEnumerable();
    await foreach (TeacherDetailEntity teacherDetail in teacherDetails)
    {
      TeacherEntity teacher = _teacherRepository.Find([teacherDetail.TeacherId])!;
      SubjectEntity subject = _subjectRepository.Find([teacherDetail.SubjectId])!;
      var details = _studentDetailRepository.GetByFilter(
        detail => detail.TeacherDetailId == teacherDetail.TeacherDetailId &&
        _classRepository.Exists(classObj => classObj.ClassId == detail.ClassId && classObj.SubjectId == teacherDetail.SubjectId),
        detail => detail.OrderBy(order => order.Student.DocumentNumber),
        detail => detail.Student)
        .ToAsyncEnumerable();
      await foreach (StudentDetailEntity detail in details)
      {
        StudentEntity student = _studentRepository.Find(student => student.StudentId == detail.StudentId)!;
        decimal credits = await GetCreditsByStudentId(student.StudentId);
        ClassStatus status = credits == TeacherCommonValues.TOTAL_CREDITS ? ClassStatus.Completed : credits > 0 && credits < TeacherCommonValues.TOTAL_CREDITS ? ClassStatus.InProgress : ClassStatus.Pending;

        yield return (teacher, student, subject, status, credits);
      }
    }
  }

  private (Guid SubjectId, Guid TeacherDetailId) GetTeacherDetailIdBySubjectId(Guid subjectId)
  {
    TeacherDetailEntity teacherDetail = _teacherDetailRepository.Find(detail => detail.SubjectId == subjectId) ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"Teacher detail not found with related subject identifier \"{subjectId}\"");

    return (subjectId, teacherDetail.TeacherDetailId);
  }

  private IEnumerable<StudentDetailEntity> GetStudentDetails(Guid studentId, Guid subjectId, Guid teacherDetailId)
    => _classRepository.GetByFilter(classObj => classObj.SubjectId == subjectId)
          .Where(classObj => !_studentDetailRepository.Exists(detail => detail.StudentId == studentId && classObj.SubjectId == subjectId))
          .Select(classObj => new StudentDetailEntity
          {
            TeacherDetailId = teacherDetailId,
            StudentId = studentId,
            ClassId = classObj.ClassId,
            Status = ClassStatus.Pending
          });

  private int GetTotalClassesBySubjectId(Guid subjectId) => _classRepository.GetByFilter(classObj => classObj.SubjectId == subjectId).Count();
}

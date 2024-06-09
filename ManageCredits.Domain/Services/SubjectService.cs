using System.Net;
using ManageCredits.Contracts.Exceptions;
using ManageCredits.Contracts.Services;
using ManageCredits.Domain.Entities;
using ManageCredits.Infrastructure.Repositories.Interfaces;
using ManageCredits.Infrastructure.Repositories.StudentCredits.Interfaces;

namespace ManageCredits.Domain.Services;

public class SubjectService(
  IStudentCreditsRepositoryContext context,
  ISubjectRepository subjectRepository,
  IClassRepository classRepository) : ISubjectService
{
  readonly IStudentCreditsRepositoryContext _context = context;
  readonly ISubjectRepository _subjectRepository = subjectRepository;
  readonly IClassRepository _classRepository = classRepository;

  public async Task<SubjectEntity> AddSubject(SubjectEntity subject)
  {
    if (_subjectRepository.Exists(entity => entity.Name.Equals(subject.Name, StringComparison.OrdinalIgnoreCase)))
      throw new ServiceErrorException(HttpStatusCode.BadRequest, $"Subject already exists with related name \"{subject.Name}\"");
    subject = _subjectRepository.Create(subject);
    _ = await _context.SaveAsync();

    return subject;
  }

  public Task<SubjectEntity> GetSubject(Guid subjectId)
  {
    SubjectEntity subject = _subjectRepository.Find([subjectId]) ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"Subject not found with related identifier \"{subjectId}\"");

    return Task.FromResult(subject);
  }

  public IAsyncEnumerable<SubjectEntity> GetSubjects() => _subjectRepository.GetAll(subject => subject.OrderBy(order => order.Name)).ToAsyncEnumerable();

  public IAsyncEnumerable<ClassEntity> GetClassesBySubjectId(Guid subjectId) => _classRepository.GetByFilter(classObj => classObj.SubjectId == subjectId, classObj => classObj.OrderBy(order => order.Name)).ToAsyncEnumerable();
}

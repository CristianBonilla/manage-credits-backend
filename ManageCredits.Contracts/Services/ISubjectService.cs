using ManageCredits.Domain.Entities;

namespace ManageCredits.Contracts.Services;

public interface ISubjectService
{
  Task<SubjectEntity> AddSubject(SubjectEntity subject);
  Task<SubjectEntity> GetSubject(Guid subjectId);
  IAsyncEnumerable<SubjectEntity> GetSubjects();
  IAsyncEnumerable<ClassEntity> GetClassesBySubjectId(Guid subjectId);
}

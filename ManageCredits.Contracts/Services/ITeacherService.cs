using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Entities.Details;

namespace ManageCredits.Contracts.Services;

public interface ITeacherService
{
  Task<(TeacherEntity, IEnumerable<TeacherDetailEntity>)> AddTeacher(TeacherEntity teacher, params Guid[] subjectIDs);
  Task<ClassEntity> AddClass(Guid teacherId, ClassEntity obj);
  IAsyncEnumerable<TeacherEntity> GetTeachers();
  IAsyncEnumerable<SubjectEntity> GetSubjectsByTeacherId(Guid teacherId);
}

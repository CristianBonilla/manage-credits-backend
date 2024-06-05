using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Entities.Details;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.Contracts.Services;

public interface IStudentService
{
  Task<(StudentEntity, IEnumerable<StudentDetailEntity>)> AddStudent(StudentEntity student, params Guid[] subjectIDs);
  Task<StudentDetailEntity> StatusChange(Guid studentId, Guid classId, ClassStatus status);
  ValueTask<decimal> GetCreditsByClassId(Guid studentId, Guid classId);
  ValueTask<decimal> GetCreditsByStudentId(Guid studentId);
  IAsyncEnumerable<string> GetStudentNamesByClassId(Guid classId, Guid exceptStudentId);
}
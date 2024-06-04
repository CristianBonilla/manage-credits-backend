using ManageCredits.Contracts.Repositories;
using ManageCredits.Domain.Entities.Details;
using ManageCredits.Infrastructure.Contexts.StudentCredits;

namespace ManageCredits.Infrastructure.Repositories.StudentCredits.Interfaces.Details;

public interface IStudentDetailRepository : IRepository<StudentCreditsContext, StudentDetailEntity> { }

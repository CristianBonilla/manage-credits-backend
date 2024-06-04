using ManageCredits.Domain.Entities.Details;
using ManageCredits.Infrastructure.Contexts.StudentCredits;
using ManageCredits.Infrastructure.Repositories.Interfaces;
using ManageCredits.Infrastructure.Repositories.StudentCredits.Interfaces.Details;

namespace ManageCredits.Infrastructure.Repositories.StudentCredits.Details;

public class StudentDetailRepository(IStudentCreditsRepositoryContext context) : Repository<StudentCreditsContext, StudentDetailEntity>(context), IStudentDetailRepository { }

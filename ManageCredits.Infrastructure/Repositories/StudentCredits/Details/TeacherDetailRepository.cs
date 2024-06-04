using ManageCredits.Domain.Entities.Details;
using ManageCredits.Infrastructure.Contexts.StudentCredits;
using ManageCredits.Infrastructure.Repositories.Interfaces;
using ManageCredits.Infrastructure.Repositories.StudentCredits.Interfaces.Details;

namespace ManageCredits.Infrastructure.Repositories.StudentCredits.Details;

public class TeacherDetailRepository(IStudentCreditsRepositoryContext context) : Repository<StudentCreditsContext, TeacherDetailEntity>(context), ITeacherDetailRepository { }

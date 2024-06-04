using ManageCredits.Domain.Entities;
using ManageCredits.Infrastructure.Contexts.StudentCredits;
using ManageCredits.Infrastructure.Repositories.Interfaces;
using ManageCredits.Infrastructure.Repositories.StudentCredits.Interfaces;

namespace ManageCredits.Infrastructure.Repositories.StudentCredits;

public class ClassRepository(IStudentCreditsRepositoryContext context) : Repository<StudentCreditsContext, ClassEntity>(context), IClassRepository { }

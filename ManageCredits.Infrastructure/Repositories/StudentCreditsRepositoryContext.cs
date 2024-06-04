using ManageCredits.Infrastructure.Contexts.StudentCredits;
using ManageCredits.Infrastructure.Repositories.Interfaces;

namespace ManageCredits.Infrastructure.Repositories;

public class StudentCreditsRepositoryContext(StudentCreditsContext context) : RepositoryContext<StudentCreditsContext>(context), IStudentCreditsRepositoryContext { }

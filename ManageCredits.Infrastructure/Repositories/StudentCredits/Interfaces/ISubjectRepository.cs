using ManageCredits.Contracts.Repositories;
using ManageCredits.Domain.Entities;
using ManageCredits.Infrastructure.Contexts.StudentCredits;

namespace ManageCredits.Infrastructure.Repositories.StudentCredits.Interfaces;

public interface ISubjectRepository : IRepository<StudentCreditsContext, SubjectEntity> { }

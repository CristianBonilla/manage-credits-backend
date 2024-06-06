using AutoMapper;
using ManageCredits.Contracts.DTO;
using ManageCredits.Contracts.DTO.Student;
using ManageCredits.Contracts.DTO.Subject;
using ManageCredits.Contracts.DTO.Teacher;
using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.API.Mappers.Profiles.Converters;

class StudentCreditsConverter : ITypeConverter<IAsyncEnumerable<(TeacherEntity, StudentEntity, SubjectEntity, ClassStatus, decimal)>, IAsyncEnumerable<StudentCreditsFilter>>
{
  public async IAsyncEnumerable<StudentCreditsFilter> Convert(
    IAsyncEnumerable<(TeacherEntity, StudentEntity, SubjectEntity, ClassStatus, decimal)> source,
    IAsyncEnumerable<StudentCreditsFilter> destination,
    ResolutionContext context)
  {
    IRuntimeMapper mapper = context.Mapper;
    await foreach (var (teacher, student, subject, status, credits) in source)
      yield return new()
      {
        Teacher = mapper.Map<TeacherEntity, TeacherResponse>(teacher),
        Student = mapper.Map<StudentEntity, StudentResponse>(student),
        Subject = mapper.Map<SubjectEntity, SubjectResponse>(subject),
        Status = status,
        Credits = credits
      };
  }
}

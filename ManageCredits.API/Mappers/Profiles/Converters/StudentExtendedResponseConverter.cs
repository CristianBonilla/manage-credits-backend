using AutoMapper;
using ManageCredits.Contracts.DTO.Student;
using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Entities.Details;

namespace ManageCredits.API.Mappers.Profiles.Converters;

class StudentExtendedResponseConverter : ITypeConverter<(StudentEntity student, IEnumerable<StudentDetailEntity> details), StudentExtendedResponse>
{
  public StudentExtendedResponse Convert(
    (StudentEntity student, IEnumerable<StudentDetailEntity> details) source,
    StudentExtendedResponse destination,
    ResolutionContext context)
  {
    IRuntimeMapper mapper = context.Mapper;
    StudentExtendedResponse studentExtended = mapper.Map<StudentEntity, StudentExtendedResponse>(source.student);
    studentExtended.Details = [.. source.details.Select(mapper.Map<StudentDetailEntity, StudentDetailResponse>)];

    return studentExtended;
  }
}

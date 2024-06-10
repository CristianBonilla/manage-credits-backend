using AutoMapper;
using ManageCredits.Contracts.DTO.Teacher;
using ManageCredits.Domain.Entities.Details;
using ManageCredits.Domain.Entities;
using ManageCredits.Contracts.DTO.Subject;

namespace ManageCredits.API.Mappers.Profiles.Converters;

class TeacherExtendedResponseConverter : ITypeConverter<(TeacherEntity teacher, IEnumerable<TeacherDetailEntity> details), TeacherExtendedResponse>
{
  public TeacherExtendedResponse Convert((TeacherEntity teacher, IEnumerable<TeacherDetailEntity> details) source, TeacherExtendedResponse destination, ResolutionContext context)
  {
    IRuntimeMapper mapper = context.Mapper;
    TeacherExtendedResponse teacherExtended = mapper.Map<TeacherEntity, TeacherExtendedResponse>(source.teacher);
    teacherExtended.Subjects = [.. source.details.Select(detail => GetSubjectDetail(mapper, detail))];

    return teacherExtended;
  }

  private static SubjectDetailResponse GetSubjectDetail(IRuntimeMapper mapper, TeacherDetailEntity teacherDetail)
  {
    SubjectDetailResponse subjectDetail = mapper.Map<SubjectEntity, SubjectDetailResponse>(teacherDetail.Subject);
    subjectDetail.TotalCredits = teacherDetail.TotalCredits;

    return subjectDetail;
  }
}

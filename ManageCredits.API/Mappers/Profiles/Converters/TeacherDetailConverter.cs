using AutoMapper;
using ManageCredits.Contracts.DTO.Teacher;
using ManageCredits.Domain.Entities.Details;
using ManageCredits.Domain.Entities;
using ManageCredits.Contracts.DTO.Subject;

namespace ManageCredits.API.Mappers.Profiles.Converters;

class TeacherDetailConverter : ITypeConverter<(TeacherEntity teacher, IEnumerable<TeacherDetailEntity> details), TeacherDetailResponse>
{
  public TeacherDetailResponse Convert((TeacherEntity teacher, IEnumerable<TeacherDetailEntity> details) source, TeacherDetailResponse destination, ResolutionContext context)
  {
    IRuntimeMapper mapper = context.Mapper;
    TeacherDetailResponse teacher = mapper.Map<TeacherEntity, TeacherDetailResponse>(source.teacher);
    teacher.Subjects = [.. source.details.Select(detail => GetSubjectDetail(mapper, detail))];

    return teacher;
  }

  private static SubjectDetailResponse GetSubjectDetail(IRuntimeMapper mapper, TeacherDetailEntity teacherDetail)
  {
    SubjectDetailResponse subjectDetail = mapper.Map<SubjectEntity, SubjectDetailResponse>(teacherDetail.Subject);
    subjectDetail.TotalCredits = teacherDetail.TotalCredits;

    return subjectDetail;
  }
}

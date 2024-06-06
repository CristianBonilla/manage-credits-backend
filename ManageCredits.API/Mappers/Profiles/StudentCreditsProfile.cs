using AutoMapper;
using ManageCredits.API.Mappers.Profiles.Converters;
using ManageCredits.Contracts.DTO;
using ManageCredits.Contracts.DTO.Class;
using ManageCredits.Contracts.DTO.Student;
using ManageCredits.Contracts.DTO.Subject;
using ManageCredits.Contracts.DTO.Teacher;
using ManageCredits.Domain.Entities;
using ManageCredits.Domain.Helpers;

namespace ManageCredits.API.Mappers.Profiles;

public class StudentCreditsProfile : Profile
{
  public StudentCreditsProfile()
  {
    CreateMap<TeacherRequest, TeacherEntity>()
      .ForMember(member => member.TeacherId, options => options.Ignore())
      .ForMember(member => member.Details, options => options.Ignore())
      .ForMember(member => member.Created, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore());
    CreateMap<TeacherEntity, TeacherResponse>();
    CreateMap<StudentRequest, StudentEntity>()
      .ForMember(member => member.StudentId, options => options.Ignore())
      .ForMember(member => member.Details, options => options.Ignore())
      .ForMember(member => member.Created, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore());
    CreateMap<StudentEntity, StudentResponse>();
    CreateMap<SubjectRequest, SubjectEntity>()
      .ForMember(member => member.SubjectId, options => options.Ignore())
      .ForMember(member => member.Classes, options => options.Ignore())
      .ForMember(member => member.Created, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore());
    CreateMap<SubjectEntity, SubjectResponse>();
    CreateMap<ClassRequest, ClassEntity>()
      .ForMember(member => member.ClassId, options => options.Ignore())
      .ForMember(member => member.Subject, options => options.Ignore())
      .ForMember(member => member.Created, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore());
    CreateMap<IAsyncEnumerable<(TeacherEntity, StudentEntity, SubjectEntity, ClassStatus, decimal)>, IAsyncEnumerable<StudentCreditsFilter>>()
      .ConvertUsing<StudentCreditsConverter>();
  }
}

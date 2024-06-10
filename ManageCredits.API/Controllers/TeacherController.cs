using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ManageCredits.Contracts.Services;
using ManageCredits.Contracts.DTO.Subject;
using ManageCredits.Domain.Entities;
using ManageCredits.Contracts.DTO.Teacher;
using ManageCredits.Domain.Entities.Details;
using ManageCredits.Contracts.DTO.Class;

namespace ManageCredits.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
public class TeacherController(IMapper mapper, ITeacherService service) : ControllerBase
{
  readonly IMapper _mapper = mapper;
  readonly ITeacherService _service = service;

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<TeacherResponse>))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async IAsyncEnumerable<TeacherResponse> GetTeachers()
  {
    var teachers = _service.GetTeachers();
    await foreach (TeacherEntity teacher in teachers)
      yield return _mapper.Map<TeacherEntity, TeacherResponse>(teacher);
  }

  [HttpGet("{teacherId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> GetTeacher(Guid teacherId)
  {
    var teacher = await _service.GetTeacher(teacherId);

    return Ok(_mapper.Map<TeacherEntity, TeacherResponse>(teacher));
  }

  [HttpGet("{teacherId}/subjects")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<SubjectResponse>))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async IAsyncEnumerable<SubjectResponse> GetSubjectsByTeacherId(Guid teacherId)
  {
    var subjects = _service.GetSubjectsByTeacherId(teacherId);
    await foreach (SubjectEntity subject in subjects)
      yield return _mapper.Map<SubjectEntity, SubjectResponse>(subject);
  }

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TeacherExtendedResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> AddTeacher([FromBody] TeacherRequest teacherRequest, [FromQuery] Guid[] subjectIDs)
  {
    TeacherEntity teacher = _mapper.Map<TeacherRequest, TeacherEntity>(teacherRequest);
    var teacherAdded = await _service.AddTeacher(teacher, subjectIDs);
    TeacherExtendedResponse teacherExtended = _mapper.Map<(TeacherEntity, IEnumerable<TeacherDetailEntity>), TeacherExtendedResponse>(teacherAdded);

    return CreatedAtAction(nameof(AddTeacher), teacherExtended);
  }

  [HttpPost("{teacherId}/classes")]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ClassResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> AddClass(Guid teacherId, [FromBody] ClassRequest classRequest)
  {
    ClassEntity classObj = _mapper.Map<ClassRequest, ClassEntity>(classRequest);
    ClassEntity addedClass = await _service.AddClass(teacherId, classObj);
    ClassResponse classResponse = _mapper.Map<ClassEntity, ClassResponse>(addedClass);

    return CreatedAtAction(nameof(AddClass), classResponse);
  }
}

using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ManageCredits.Contracts.Services;
using ManageCredits.Contracts.DTO.Subject;
using ManageCredits.Domain.Entities;
using ManageCredits.Contracts.DTO.Class;

namespace ManageCredits.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
public class SubjectController(IMapper mapper, ISubjectService service) : ControllerBase
{
  readonly IMapper _mapper = mapper;
  readonly ISubjectService _service = service;

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<SubjectResponse>))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async IAsyncEnumerable<SubjectResponse> GetSubjects()
  {
    var subjects = _service.GetSubjects();
    await foreach (SubjectEntity subject in subjects)
      yield return _mapper.Map<SubjectEntity, SubjectResponse>(subject);
  }

  [HttpGet("{subjectId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> GetSubject(Guid subjectId)
  {
    SubjectEntity subject = await _service.GetSubject(subjectId);
    SubjectResponse subjectResponse = _mapper.Map<SubjectEntity, SubjectResponse>(subject);

    return Ok(subjectResponse);
  }

  [HttpGet("{subjectId}/classes")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<ClassResponse>))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async IAsyncEnumerable<ClassResponse> GetClassesBySubjectId(Guid subjectId)
  {
    var classes = _service.GetClassesBySubjectId(subjectId);
    await foreach (ClassEntity classObj in classes)
      yield return _mapper.Map<ClassEntity, ClassResponse>(classObj);
  }

  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SubjectResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> AddSubject([FromBody] SubjectRequest subjectRequest)
  {
    SubjectEntity subject = _mapper.Map<SubjectRequest, SubjectEntity>(subjectRequest);
    subject = await _service.AddSubject(subject);
    SubjectResponse subjectResponse = _mapper.Map<SubjectEntity, SubjectResponse>(subject);

    return CreatedAtAction(nameof(AddSubject), subjectResponse);
  }
}

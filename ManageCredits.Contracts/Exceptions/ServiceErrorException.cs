using System.Net;
using ManageCredits.Contracts.DTO;

namespace ManageCredits.Contracts.Exceptions;

public class ServiceErrorException : Exception
{
  public HttpStatusCode Status { get; }

  public ServiceError Errors { get; } = null!;

  public ServiceErrorException(HttpStatusCode status, params string[] errors)
  {
    Status = status;
    Errors = new() { Errors = new HashSet<string>(errors) };
  }
}

using Microsoft.AspNetCore.Http;

namespace SignalRChat_Server.Dtos
{
    public sealed record RegisterDto(
        string Name,
        IFormFile File
      );

}

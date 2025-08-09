using GenericFileService.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRChat_Server.Context;
using SignalRChat_Server.Dtos;
using SignalRChat_Server.Hubs;
using SignalRChat_Server.Models;

namespace SignalRChat_Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public sealed class AuthController(ApplicationDbContext context) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromForm]RegisterDto request,CancellationToken cancellationToken)
        {
            bool isNameExists= await context.Users.AnyAsync(p=>p.Name==request.Name,cancellationToken);
            if (isNameExists)
            {
                return BadRequest("This name has been used before! ");
            }
            string avatar = FileService.FileSaveToServer(request.File, "C:\\Users\\elesg\\OneDrive\\Desktop\\ChatSignalR_Project\\SignalRChat_Server\\SignalRChat_Server\\wwwroot\\avatar\\");
            User user = new()
            {
                Name = request.Name,
                Avatar=avatar
            };

            await context.Users.AddAsync(user,cancellationToken);
            await context.SaveChangesAsync();
            return Ok(user);
        }
        [HttpGet]
        public async Task<IActionResult> Login(string name ,CancellationToken cancellationToken)
        {
            User user= await context.Users.FirstOrDefaultAsync(p=>p.Name==name,cancellationToken);
            if (user==null)
            {
                return BadRequest(new {Message= "User not found!" });
            }
            user.Status = "online";
            await context.SaveChangesAsync(cancellationToken);
            return Ok(user);

        }
    }
}

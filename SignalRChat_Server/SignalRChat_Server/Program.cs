using Microsoft.EntityFrameworkCore;
using SignalRChat_Server.Context;
using SignalRChat_Server.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
     policy.AllowAnyMethod()
     .AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(otigin => true)));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/Chat-hub");

app.Run();

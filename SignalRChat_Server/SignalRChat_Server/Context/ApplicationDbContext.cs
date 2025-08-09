using Microsoft.EntityFrameworkCore;
using SignalRChat_Server.Models;

namespace SignalRChat_Server.Context
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
    }
}

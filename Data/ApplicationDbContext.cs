using Microsoft.EntityFrameworkCore;

namespace SimpleRedditApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Thread> Threads { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}

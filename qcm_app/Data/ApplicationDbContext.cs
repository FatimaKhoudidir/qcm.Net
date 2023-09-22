using Microsoft.EntityFrameworkCore;
using qcm_app.Models;

namespace qcm_app.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<User> User { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Choice> Choice { get; set; }
    }
}

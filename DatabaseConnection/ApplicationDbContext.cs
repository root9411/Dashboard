using BlackcofferAssigment.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackcofferAssigment.DatabaseConnection
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserRegistration> registrations { get; set; }
        public DbSet<UserData> AssigmentData { get; set; }
    }
}

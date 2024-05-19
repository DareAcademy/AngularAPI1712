using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Clinic1712Angular.data
{
    public class ClinicContext:IdentityDbContext<ApplicationUser>
    {
        IConfiguration config;

        public ClinicContext(IConfiguration _config)
        {
            config = _config;
        }
        public DbSet<Country> countries { get; set; }
        public DbSet<Patient> patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("ClinicConn"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}

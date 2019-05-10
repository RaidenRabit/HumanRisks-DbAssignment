using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class RiskAssessmentDbContext : DbContext
    {

        public DbSet<RiskAssessment>RiskAssessments { get; set; }
        public DbSet<Threat>Threats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Localhost;Database=RiskAssessmentDB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
       
        
    }

}

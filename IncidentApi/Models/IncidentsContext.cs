using Microsoft.EntityFrameworkCore;

namespace IncidentApi.Models
{
    public class IncidentsContext : DbContext
    {
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public IncidentsContext(DbContextOptions<IncidentsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=IncidentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>().ToTable("Incident");
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Contact>().ToTable("Contact");
        }
    }
}

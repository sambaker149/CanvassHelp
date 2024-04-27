using Microsoft.EntityFrameworkCore;
using CanvassHelp.Models;

namespace CanvassHelp.Data
{
    public class CanvassHelpContext : DbContext
    {
        public CanvassHelpContext(DbContextOptions<CanvassHelpContext> options)
            : base(options)
        {
        }

        public DbSet<Grouping> Groupings { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<NewResidentRequest> ResidentRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grouping>().ToTable("Grouping");
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<Resident>().ToTable("Resident");
            modelBuilder.Entity<NewResidentRequest>().ToTable("NewResidentRequest");
        }
    }
}
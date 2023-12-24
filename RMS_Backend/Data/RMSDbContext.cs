using Microsoft.EntityFrameworkCore;
using RMS_Backend.Models;

namespace RMS_Backend.Data
{
    public class RMSDbContext : DbContext
    {
        public RMSDbContext(DbContextOptions<RMSDbContext> options) : base(options) //need to figure out about constructor because there ar so many similar
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //setting timestamp property for publications
            modelBuilder.Entity<PublicationScopus>()
            .Property(e => e.PublicationDate)
            .HasColumnType("timestamp");

            modelBuilder.Entity<PublicationWebOfScience>()
            .Property(e => e.PublicationDate)
            .HasColumnType("timestamp");

            //setting constraints for User->Scopus
            modelBuilder.Entity<User>()
                .HasMany(a => a.PublicationsScopus)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.PersonnelNumber);

            //setting constraints for User->WoS
            modelBuilder.Entity<User>()
                .HasMany(a => a.PublicationsWebOfScience)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.PersonnelNumber);
        }

        //adding DbSets of Tables in our database
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<PublicationScopus> PublicationsScopus { get; set; }
        public DbSet<PublicationWebOfScience> PublicationsWebOfScience { get; set; }
    }
}

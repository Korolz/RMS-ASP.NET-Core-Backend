using Microsoft.EntityFrameworkCore;
using RMS_Backend.Models;

namespace RMS_Backend.Data
{
    public class RMSDbContext : DbContext
    {
        public RMSDbContext(DbContextOptions<RMSDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //setting Primary Keys
            modelBuilder.Entity<User>().HasKey(u => u.PersonnelNumber);
            modelBuilder.Entity<Publication>().HasKey(p => p.DOI);
            modelBuilder.Entity<PublicationScopus>().HasKey(p => p.DOI);
            modelBuilder.Entity<PublicationWebOfScience>().HasKey(p => p.DOI);

            //setting requirements
            modelBuilder.Entity<User>().Property(u => u.PersonnelNumber).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Username).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.AdminType).HasDefaultValue(0);

            modelBuilder.Entity<Publication>().Property(p => p.DOI).IsRequired();
            modelBuilder.Entity<Publication>().Property(p => p.Title).IsRequired();
            modelBuilder.Entity<Publication>().Property(p => p.Status).HasDefaultValue("Waiting");

            modelBuilder.Entity<PublicationScopus>().Property(p => p.DOI).IsRequired();
            //modelBuilder.Entity<PublicationScopus>().Property(p => p.DOI).IsRequired();

            modelBuilder.Entity<PublicationWebOfScience>().Property(p => p.DOI).IsRequired();
            //modelBuilder.Entity<PublicationWebOfScience>().Property(p => p.DOI).IsRequired();
            modelBuilder.Entity<PublicationWebOfScience>().Property(p => p.HasAbroadAuthor).HasDefaultValue(false);
            modelBuilder.Entity<PublicationWebOfScience>().Property(p => p.IsAbroadAuthorTop400).HasDefaultValue(false);

            //setting timestamp property for publications
            modelBuilder.Entity<Publication>().Property(p => p.PublicationDate).HasColumnType("timestamp");

            //setting one-to-one relation
            modelBuilder.Entity<Publication>()
                .HasOne(p => p.PublicationScopus)
                .WithOne(ps => ps.Publication)
                .HasForeignKey<PublicationScopus>(ps => ps.DOI);

            modelBuilder.Entity<Publication>()
                .HasOne(p => p.PublicationWebOfScience)
                .WithOne(ps => ps.Publication)
                .HasForeignKey<PublicationWebOfScience>(wos => wos.DOI);

            //setting one-to-many relation

            ////setting relation for User->Publications
            //modelBuilder.Entity<Publication>()
            //    .HasOne(p => p.User)
            //    .WithMany(u => u.Publications)
            //    .HasForeignKey(p => p.PersonnelNumber);

            ////setting relation for Publication->WoS
            //modelBuilder.Entity<Publication>()
            //    .HasOne(p => p.PublicationWebOfScience)
            //    .WithOne(w => w.Publication)
            //    .HasForeignKey<PublicationWebOfScience>(w => w.DOI);

            ////setting relation for Publication->Scopus
            //modelBuilder.Entity<Publication>()
            //    .HasOne(p => p.PublicationScopus)
            //    .WithOne(s => s.Publication)
            //    .HasForeignKey<PublicationScopus>(s => s.DOI);
        }

        //adding DbSets of Tables in our database
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Publication> Publications { get; set; }
        public DbSet<PublicationScopus> PublicationsScopus { get; set; }
        public DbSet<PublicationWebOfScience> PublicationsWebOfScience { get; set; }
    }
}

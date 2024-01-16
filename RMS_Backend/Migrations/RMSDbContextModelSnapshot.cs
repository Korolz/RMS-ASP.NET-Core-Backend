﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RMS_Backend.Data;

#nullable disable

namespace RMS_Backend.Migrations
{
    [DbContext(typeof(RMSDbContext))]
    partial class RMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RMS_Backend.Models.Publication", b =>
                {
                    b.Property<string>("DOI")
                        .HasColumnType("text");

                    b.Property<string>("Authors")
                        .HasColumnType("text");

                    b.Property<int?>("AuthorsNo")
                        .HasColumnType("integer");

                    b.Property<string>("JournalISSN")
                        .HasColumnType("text");

                    b.Property<string>("JournalTitle")
                        .HasColumnType("text");

                    b.Property<int?>("No")
                        .HasColumnType("integer");

                    b.Property<string>("Pages")
                        .HasColumnType("text");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("timestamp");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("Waiting");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserPersonnelNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Vol")
                        .HasColumnType("integer");

                    b.HasKey("DOI");

                    b.HasIndex("UserPersonnelNumber");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("RMS_Backend.Models.PublicationScopus", b =>
                {
                    b.Property<string>("DOI")
                        .HasColumnType("text");

                    b.HasKey("DOI");

                    b.ToTable("PublicationsScopus");
                });

            modelBuilder.Entity("RMS_Backend.Models.PublicationWebOfScience", b =>
                {
                    b.Property<string>("DOI")
                        .HasColumnType("text");

                    b.Property<bool>("HasAbroadAuthor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsAbroadAuthorTop400")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Top400UniversityName")
                        .HasColumnType("text");

                    b.Property<string>("WOSNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DOI");

                    b.ToTable("PublicationsWebOfScience");
                });

            modelBuilder.Entity("RMS_Backend.Models.User", b =>
                {
                    b.Property<string>("PersonnelNumber")
                        .HasColumnType("text");

                    b.Property<int>("AdminType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("Department")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Faculty")
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PersonnelNumber");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RMS_Backend.Models.Publication", b =>
                {
                    b.HasOne("RMS_Backend.Models.User", "User")
                        .WithMany("Publications")
                        .HasForeignKey("UserPersonnelNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RMS_Backend.Models.PublicationScopus", b =>
                {
                    b.HasOne("RMS_Backend.Models.Publication", "Publication")
                        .WithOne("PublicationScopus")
                        .HasForeignKey("RMS_Backend.Models.PublicationScopus", "DOI")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publication");
                });

            modelBuilder.Entity("RMS_Backend.Models.PublicationWebOfScience", b =>
                {
                    b.HasOne("RMS_Backend.Models.Publication", "Publication")
                        .WithOne("PublicationWebOfScience")
                        .HasForeignKey("RMS_Backend.Models.PublicationWebOfScience", "DOI")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publication");
                });

            modelBuilder.Entity("RMS_Backend.Models.Publication", b =>
                {
                    b.Navigation("PublicationScopus");

                    b.Navigation("PublicationWebOfScience");
                });

            modelBuilder.Entity("RMS_Backend.Models.User", b =>
                {
                    b.Navigation("Publications");
                });
#pragma warning restore 612, 618
        }
    }
}

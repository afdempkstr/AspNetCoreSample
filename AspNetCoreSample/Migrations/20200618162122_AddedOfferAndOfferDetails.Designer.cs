﻿// <auto-generated />
using System;
using AspNetCoreSample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetCoreSample.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200618162122_AddedOfferAndOfferDetails")]
    partial class AddedOfferAndOfferDetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetCoreSample.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPopularCandidate")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SpecialCase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecialisationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecialisationId");

                    b.ToTable("Candidates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Lorem Ipsum",
                            FirstName = "Nick",
                            ImageThumbnailUrl = "https://randomuser.me/api/portraits/lego/5.jpg",
                            IsAvailable = true,
                            IsPopularCandidate = true,
                            LastName = "Papadopoulos",
                            Rating = 15.95m,
                            SpecialisationId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Lorem Ipsum",
                            FirstName = "John",
                            ImageThumbnailUrl = "https://randomuser.me/api/portraits/lego/3.jpg",
                            IsAvailable = true,
                            IsPopularCandidate = false,
                            LastName = "Katinas",
                            Rating = 16.34m,
                            SpecialisationId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Lorem Ipsum",
                            FirstName = "George",
                            ImageThumbnailUrl = "https://randomuser.me/api/portraits/lego/8.jpg",
                            IsAvailable = true,
                            IsPopularCandidate = false,
                            LastName = "Floyd",
                            Rating = 17.12m,
                            SpecialisationId = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "Black Lives Matter",
                            FirstName = "Breonna",
                            ImageThumbnailUrl = "https://randomuser.me/api/portraits/lego/2.jpg",
                            IsAvailable = true,
                            IsPopularCandidate = true,
                            LastName = "Taylor",
                            Rating = 18.44m,
                            SpecialisationId = 3
                        });
                });

            modelBuilder.Entity("AspNetCoreSample.Models.Offer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OfferPlacedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OfferTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("AspNetCoreSample.Models.OfferDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.Property<int>("OfferPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("OfferId");

                    b.ToTable("OfferDetails");
                });

            modelBuilder.Entity("AspNetCoreSample.Models.SelectedTeamCandidate", b =>
                {
                    b.Property<int>("SelectedTeamCandidateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CandidateId")
                        .HasColumnType("int");

                    b.Property<int>("OfferPrice")
                        .HasColumnType("int");

                    b.Property<string>("SelectedTeamId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SelectedTeamCandidateId");

                    b.HasIndex("CandidateId");

                    b.ToTable("SelectedTeamCandidates");
                });

            modelBuilder.Entity("AspNetCoreSample.Models.Specialisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specialisations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A C# back end Developer...",
                            Name = "C# Developer"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A Java back end Developer...",
                            Name = "Java Developer"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A developer who can write everything",
                            Name = "Full-Stack Developer"
                        });
                });

            modelBuilder.Entity("AspNetCoreSample.Models.Candidate", b =>
                {
                    b.HasOne("AspNetCoreSample.Models.Specialisation", "Specialisation")
                        .WithMany("Candidates")
                        .HasForeignKey("SpecialisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspNetCoreSample.Models.OfferDetail", b =>
                {
                    b.HasOne("AspNetCoreSample.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCoreSample.Models.Offer", "Request")
                        .WithMany("OfferDetails")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspNetCoreSample.Models.SelectedTeamCandidate", b =>
                {
                    b.HasOne("AspNetCoreSample.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId");
                });
#pragma warning restore 612, 618
        }
    }
}

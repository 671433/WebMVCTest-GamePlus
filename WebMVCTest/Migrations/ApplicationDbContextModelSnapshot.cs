﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebMVCTest.Data;

#nullable disable

namespace WebMVCTest.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebMVCTest.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Sports"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Action"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Adventure"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Racing"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Fighting"
                        },
                        new
                        {
                            ID = 6,
                            Name = "Film"
                        });
                });

            modelBuilder.Entity("WebMVCTest.Models.Device", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.ToTable("Devices");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Icon = "bi bi-playstation",
                            Name = "PlayStation"
                        },
                        new
                        {
                            ID = 2,
                            Icon = "bi bi-xbox",
                            Name = "Xbox"
                        },
                        new
                        {
                            ID = 3,
                            Icon = "bi bi-nintendo-switch",
                            Name = "Nintendo Switch"
                        },
                        new
                        {
                            ID = 4,
                            Icon = "bi bi-pc",
                            Name = "PC"
                        });
                });

            modelBuilder.Entity("WebMVCTest.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("WebMVCTest.Models.GameDevice", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("DeviceID")
                        .HasColumnType("int");

                    b.HasKey("GameId", "DeviceID");

                    b.HasIndex("DeviceID");

                    b.ToTable("GameDevice");
                });

            modelBuilder.Entity("WebMVCTest.Models.Game", b =>
                {
                    b.HasOne("WebMVCTest.Models.Category", "Category")
                        .WithMany("Games")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebMVCTest.Models.GameDevice", b =>
                {
                    b.HasOne("WebMVCTest.Models.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebMVCTest.Models.Game", "Game")
                        .WithMany("Devices")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("WebMVCTest.Models.Category", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("WebMVCTest.Models.Game", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}

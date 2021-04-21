﻿// <auto-generated />
using System;
using LibraryManagementBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryManagement.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20210421102845_Initial1")]
    partial class Initial1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryManagementBackend.Models.Entity.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ShortContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            ShortContent = "Gacha for your life",
                            Title = "Genshin Impact",
                            Url = "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            ShortContent = "Gacha for your life",
                            Title = "Genshin Impact",
                            Url = "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            ShortContent = "Gacha for your life",
                            Title = "Genshin Impact",
                            Url = "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            ShortContent = "Gacha for your life",
                            Title = "Genshin Impact",
                            Url = "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            ShortContent = "Gacha for your life",
                            Title = "Genshin Impact",
                            Url = "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            ShortContent = "Gacha for your life",
                            Title = "Genshin Impact",
                            Url = "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png"
                        });
                });

            modelBuilder.Entity("LibraryManagementBackend.Models.Entity.BorrowingRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApprovalUserId")
                        .HasColumnType("int");

                    b.Property<int?>("RejectUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequestUserId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RequestUserId");

                    b.ToTable("BorrowingRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApprovalUserId = 1,
                            RequestDate = new DateTime(2021, 4, 14, 17, 28, 44, 611, DateTimeKind.Local).AddTicks(4319),
                            RequestUserId = 2,
                            Status = 1,
                            UpdateDate = new DateTime(2021, 4, 21, 16, 28, 44, 612, DateTimeKind.Local).AddTicks(5541)
                        },
                        new
                        {
                            Id = 2,
                            ApprovalUserId = 1,
                            RequestDate = new DateTime(2021, 4, 14, 17, 28, 44, 612, DateTimeKind.Local).AddTicks(6950),
                            RequestUserId = 2,
                            Status = 1,
                            UpdateDate = new DateTime(2021, 4, 21, 16, 28, 44, 612, DateTimeKind.Local).AddTicks(6957)
                        },
                        new
                        {
                            Id = 3,
                            ApprovalUserId = 1,
                            RequestDate = new DateTime(2021, 4, 14, 17, 28, 44, 612, DateTimeKind.Local).AddTicks(6961),
                            RequestUserId = 2,
                            Status = 1,
                            UpdateDate = new DateTime(2021, 4, 21, 16, 28, 44, 612, DateTimeKind.Local).AddTicks(6962)
                        });
                });

            modelBuilder.Entity("LibraryManagementBackend.Models.Entity.BorrowingRequestDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("RequestId");

                    b.ToTable("BorrowingRequestDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            RequestId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            RequestId = 1
                        });
                });

            modelBuilder.Entity("LibraryManagementBackend.Models.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Game"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Novel"
                        });
                });

            modelBuilder.Entity("LibraryManagementBackend.Models.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Member"
                        });
                });

            modelBuilder.Entity("LibraryManagementBackend.Models.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "123",
                            RoleId = 1,
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Password = "123",
                            RoleId = 2,
                            Username = "member"
                        });
                });

            modelBuilder.Entity("LibraryManagementBackend.Models.Entity.Book", b =>
                {
                    b.HasOne("LibraryManagementBackend.Models.Entity.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LibraryManagementBackend.Models.Entity.BorrowingRequest", b =>
                {
                    b.HasOne("LibraryManagementBackend.Models.Entity.User", "RequestUser")
                        .WithMany("Requests")
                        .HasForeignKey("RequestUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestUser");
                });

            modelBuilder.Entity("LibraryManagementBackend.Models.Entity.BorrowingRequestDetails", b =>
                {
                    b.HasOne("LibraryManagementBackend.Models.Entity.Book", "Book")
                        .WithMany("RequestDetails")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagementBackend.Models.Entity.BorrowingRequest", "Request")
                        .WithMany("RequestDetails")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("LibraryManagementBackend.Models.Entity.User", b =>
                {
                    b.HasOne("LibraryManagementBackend.Models.Entity.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LibraryManagementBackend.Models.Entity.Book", b =>
                {
                    b.Navigation("RequestDetails");
                });

            modelBuilder.Entity("LibraryManagementBackend.Models.Entity.BorrowingRequest", b =>
                {
                    b.Navigation("RequestDetails");
                });

            modelBuilder.Entity("LibraryManagementBackend.Models.Entity.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryManagementBackend.Models.Entity.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("LibraryManagementBackend.Models.Entity.User", b =>
                {
                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}

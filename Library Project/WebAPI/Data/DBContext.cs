using System;
using Microsoft.EntityFrameworkCore;
using WebAPI.Enums;
using WebAPI.Models;

namespace WebAPI.Data
{
  public class DBContext : DbContext
  {
    public DBContext(DbContextOptions<DBContext> options)
         : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BorrowingRequest> BorrowingRequests { get; set; }
    public DbSet<BorrowingRequestDetails> BorrowingRequestDetails { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("Server = DESKTOP-L257EVI\\SQLEXPRESS; Database = LibraryManagement; Trusted_Connection=True; MultipleActiveResultSets = true");
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Category>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

      builder.Entity<Category>()
            .HasData(
              new Category
              {
                Id = 1,
                CategoryName = "Game"
              },
              new Category
              {
                Id = 2,
                CategoryName = "Novel"
              }
            );

      builder.Entity<User>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

      builder.Entity<User>()
            .HasData(
              new User
              {
                Id = 1,
                Username = "admin",
                Password = "123",
                Role = (Role)0
              },
              new User
              {
                Id = 2,
                Username = "member",
                Password = "123",
                Role = (Role)1
              }
            );

      builder.Entity<Book>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

      builder.Entity<Book>()
            .HasOne(i => i.Category)
            .WithMany(c => c.Books)
            .OnDelete(DeleteBehavior.Cascade);

      builder.Entity<Book>()
            .HasData(
                new Book()
                {
                  Id = 1,
                  BookTitle = "Genshin Impact",
                  BookDescription = "Gacha for your life",
                  CategoryId = 1
                },
                new Book()
                {
                  Id = 2,
                  BookTitle = "Romeo and Juliet",
                  BookDescription = "Suicide go brr brr",
                  CategoryId = 2
                },
                new Book()
                {
                  Id = 3,
                  BookTitle = "Romeo and Juliet",
                  BookDescription = "Suicide go brr brr",
                  CategoryId = 2
                },
                new Book()
                {
                  Id = 4,
                  BookTitle = "Romeo and Juliet",
                  BookDescription = "Suicide go brr brr",
                  CategoryId = 2
                },
                new Book()
                {
                  Id = 5,
                  BookTitle = "Romeo and Juliet",
                  BookDescription = "Suicide go brr brr",
                  CategoryId = 2
                },
                new Book()
                {
                  Id = 6,
                  BookTitle = "Romeo and Juliet",
                  BookDescription = "Suicide go brr brr",
                  CategoryId = 2
                }
            );

      builder.Entity<BorrowingRequest>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

      builder.Entity<BorrowingRequest>()
            .HasOne(a => a.RequestUser)
            .WithMany(c => c.BookBorrowingRequests)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
      builder.Entity<BorrowingRequest>()
            .HasData(
              new BorrowingRequest
              {
                Id = 1,
                Status = (Status)1,
                RequestDate = DateTime.Now.AddDays(-7),
                ReturnDate = DateTime.Now.AddHours(-1),
                RequestUserId = 2,
                ApprovalUserId = 1
              },
              new BorrowingRequest
              {
                Id = 2,
                Status = (Status)1,
                RequestDate = DateTime.Now.AddDays(-7),
                ReturnDate = DateTime.Now.AddHours(-1),
                RequestUserId = 2,
                ApprovalUserId = 1
              },
              new BorrowingRequest
              {
                Id = 3,
                Status = (Status)1,
                RequestDate = DateTime.Now.AddDays(-7),
                ReturnDate = DateTime.Now.AddHours(-1),
                RequestUserId = 2,
                ApprovalUserId = 1
              }
            );

      builder.Entity<BorrowingRequestDetails>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

      builder.Entity<BorrowingRequestDetails>()
            .HasOne(a => a.Book)
            .WithMany(c => c.BorrowingRequestDetails)
            .OnDelete(DeleteBehavior.Cascade);

      builder.Entity<BorrowingRequestDetails>()
            .HasOne(a => a.Request)
            .WithMany(c => c.BorrowingRequestDetails)
            .OnDelete(DeleteBehavior.Cascade);

      builder.Entity<BorrowingRequestDetails>()
            .HasData(
              new BorrowingRequestDetails
              {
                Id = 1,
                BookId = 1,
                RequestId = 1
              },
              new BorrowingRequestDetails
              {
                Id = 2,
                BookId = 2,
                RequestId = 1
              }
            );

    }
  }
}

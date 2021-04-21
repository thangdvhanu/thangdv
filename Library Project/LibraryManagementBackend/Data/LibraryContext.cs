using System;
using LibraryManagementBackend.Data.Enums;
using LibraryManagementBackend.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementBackend.Data
{
  public class LibraryContext : DbContext
  {
    public LibraryContext(DbContextOptions<LibraryContext> options)
         : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<BorrowingRequest> BorrowingRequests { get; set; }
    public DbSet<BorrowingRequestDetails> BorrowingRequestDetails { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("Server = DESKTOP-L257EVI\\SQLEXPRESS; Database = Library; Trusted_Connection=True; MultipleActiveResultSets = true");
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {

      builder.Entity<Role>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

      builder.Entity<Role>()
            .HasData(
              new Role
              {
                Id = 1,
                Name = "Admin"
              },
              new Role
              {
                Id = 2,
                Name = "Member"
              }
            );

      builder.Entity<Category>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

      builder.Entity<Category>()
            .HasData(
              new Category
              {
                Id = 1,
                Name = "Game"
              },
              new Category
              {
                Id = 2,
                Name = "Novel"
              }
            );

      builder.Entity<User>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

      builder.Entity<User>()
            .HasOne(i => i.Role)
            .WithMany(c => c.Users)
            .OnDelete(DeleteBehavior.Cascade);

      builder.Entity<User>()
            .HasData(
              new User
              {
                Id = 1,
                Username = "admin",
                Password = "123",
                RoleId = 1
              },
              new User
              {
                Id = 2,
                Username = "member",
                Password = "123",
                RoleId = 2
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
                  Title = "Genshin Impact",
                  ShortContent = "Gacha for your life",
                  Url = "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png",
                  CategoryId = 1
                },
                new Book()
                {
                  Id = 2,
                  Title = "Genshin Impact",
                  ShortContent = "Gacha for your life",
                  Url = "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png",
                  CategoryId = 2
                },
                new Book()
                {
                  Id = 3,
                  Title = "Genshin Impact",
                  ShortContent = "Gacha for your life",
                  Url = "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png",
                  CategoryId = 2
                },
                new Book()
                {
                  Id = 4,
                  Title = "Genshin Impact",
                  ShortContent = "Gacha for your life",
                  Url = "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png",
                  CategoryId = 2
                },
                new Book()
                {
                  Id = 5,
                  Title = "Genshin Impact",
                  ShortContent = "Gacha for your life",
                  Url = "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png",
                  CategoryId = 2
                },
                new Book()
                {
                  Id = 6,
                  Title = "Genshin Impact",
                  ShortContent = "Gacha for your life",
                  Url = "https://uploadstatic-sea.mihoyo.com/contentweb/20210122/2021012210173258296.png",
                  CategoryId = 2
                }
            );

      builder.Entity<BorrowingRequest>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

      builder.Entity<BorrowingRequest>()
            .HasOne(a => a.RequestUser)
            .WithMany(c => c.Requests)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
      builder.Entity<BorrowingRequest>()
            .HasData(
              new BorrowingRequest
              {
                Id = 1,
                Status = Status.Approved,
                RequestDate = DateTime.Now.AddDays(-7),
                UpdateDate = DateTime.Now.AddHours(-1),
                RequestUserId = 2,
                ApprovalUserId = 1
              },
              new BorrowingRequest
              {
                Id = 2,
                Status = Status.Approved,
                RequestDate = DateTime.Now.AddDays(-7),
                UpdateDate = DateTime.Now.AddHours(-1),
                RequestUserId = 2,
                ApprovalUserId = 1
              },
              new BorrowingRequest
              {
                Id = 3,
                Status = Status.Approved,
                RequestDate = DateTime.Now.AddDays(-7),
                UpdateDate = DateTime.Now.AddHours(-1),
                RequestUserId = 2,
                ApprovalUserId = 1
              }
            );

      builder.Entity<BorrowingRequestDetails>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

      builder.Entity<BorrowingRequestDetails>()
            .HasOne(a => a.Book)
            .WithMany(c => c.RequestDetails)
            .OnDelete(DeleteBehavior.Cascade);

      builder.Entity<BorrowingRequestDetails>()
            .HasOne(a => a.Request)
            .WithMany(c => c.RequestDetails)
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

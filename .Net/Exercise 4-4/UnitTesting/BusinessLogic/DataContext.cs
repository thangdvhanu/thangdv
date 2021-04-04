using System;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class DataContext : DbContext
    {
        private readonly Action<DataContext, ModelBuilder> _customizeModel;
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DataContext(DbContextOptions<DataContext> options, Action<DataContext, ModelBuilder> customizeModel)
            : base(options)
        {
            // customizeModel must be the same for every instance in a given application.
            // Otherwise a custom IModelCacheKeyFactory implementation must be provided.
            _customizeModel = customizeModel;
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            if (!option.IsConfigured)
            {
                option.UseSqlServer("Server = DESKTOP-L257EVI\\SQLEXPRESS;Database = TestEFCore;Trusted_Connection=True;MultipleActiveResultSets= true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasIndex(e => e.BlogId, "IX_Posts_BlogId");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.BlogId);
            });
        }
    }
}

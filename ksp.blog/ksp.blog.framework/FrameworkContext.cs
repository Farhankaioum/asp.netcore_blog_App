using ksp.blog.framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace ksp.blog.framework
{
    public class FrameworkContext : DbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public FrameworkContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {

                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // configure Blog class property
            builder.Entity<Blog>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Entity<Blog>()
                .Property(b => b.Description)
                .IsRequired();

            builder.Entity<Blog>()
                .Property(b => b.AuthorId)
                .IsRequired()
                .HasMaxLength(255);

            // Many to many releationship added between Blog to Category
            builder.Entity<BlogCategory>()
                .HasKey(bc => new { bc.BlogId, bc.CategoryId });

            builder.Entity<BlogCategory>()
                .HasOne(b => b.Blog)
                .WithMany(bc => bc.BlogCategories)
                .HasForeignKey(p => p.BlogId);

            builder.Entity<BlogCategory>()
                .HasOne(c => c.Category)
                .WithMany(bc => bc.BlogCategories)
                .HasForeignKey(c => c.CategoryId);

            base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
    }
}

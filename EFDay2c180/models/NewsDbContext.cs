using EFDay2c180.models;
using Microsoft.EntityFrameworkCore;

namespace NewsDatabase
{
    public class NewsContext : DbContext
    {
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=LearnIt; ;Trusted_Connection=True;TrustServerCertificate=True;")
                .UseLazyLoadingProxies();
        }

        public DbSet<Category> Catalogs { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}

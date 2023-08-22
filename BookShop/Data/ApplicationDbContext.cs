using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        {

        }

        public DbSet<Category> category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Action",
                    DisplayOrder =1  
                }, new Category
                {
                    Id = 2,
                    Name = "Action",
                    DisplayOrder = 3
                },
            
            new Category
                {
                    Id = 3,
                    Name = "Action",
                    DisplayOrder =5  
                },
            new Category
                {
                    Id = 4,
                    Name = "SciFi",
                    DisplayOrder =2  
                }, new Category
                {
                    Id = 5,
                    Name = "Drama",
                    DisplayOrder =4  
                } );
        }
    }
}

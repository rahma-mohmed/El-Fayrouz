using Microsoft.EntityFrameworkCore;

namespace Fayroz.Models
{
    public class FayrozDbContext : DbContext
    {
        public FayrozDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<OrderRecipeDetails> OrderRecipeDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category { Id = 1, Name = "Cake" },
                new Category { Id = 2, Name = "Pie" },
                new Category { Id = 3, Name = "Biscuit" },
                new Category { Id = 4, Name = "Sable" },
                new Category { Id = 5, Name = "Kunafa" },
                new Category { Id = 6, Name = "Pancake" }
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

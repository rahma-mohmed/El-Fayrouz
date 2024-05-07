using Fayroz.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fayroz.ContextDbConfig
{
    public class FayrozDbContext : IdentityDbContext<User>
    {
        public FayrozDbContext(DbContextOptions<FayrozDbContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category { Id = 1, Name = "Cake" },
                new Category { Id = 2, Name = "Pie" },
                new Category { Id = 3, Name = "Biscuit" },
                new Category { Id = 4, Name = "Sable" },
                new Category { Id = 5, Name = "Kunafa" },
                new Category { Id = 6, Name = "Pancake" },
                new Category { Id = 7, Name = "Pastries" },
                new Category { Id = 8, Name = "Ice cream" },
                new Category { Id = 9, Name = "Coffee" },
                new Category { Id = 10, Name = "Basbousa" },
                new Category { Id = 11, Name = "Donats" },
                new Category { Id = 12, Name = "Other" },
            });

            modelBuilder.Entity<Address>().HasData(new Address[]
            {
                new Address { Id = 1, CityName = "Damietta", DeliveryPrice = 20 },
                new Address { Id = 2, CityName = "New Damietta", DeliveryPrice = 20 },
                new Address { Id = 3, CityName = "Ras El Bar", DeliveryPrice = 20 },
                new Address { Id = 4, CityName = "Kafr Saad", DeliveryPrice = 20 },
                new Address { Id = 5, CityName = "Faraskur", DeliveryPrice = 10 },
                new Address { Id = 6, CityName = "Zarqa", DeliveryPrice = 25 },
                new Address { Id = 7, CityName = "Kafr El-Battikh", DeliveryPrice = 25 },
                new Address { Id = 8, CityName = "El-Zarka", DeliveryPrice = 25 },
                new Address { Id = 9, CityName = "Sherbin", DeliveryPrice = 25 },
                new Address { Id = 10, CityName = "Azbet El-Borg", DeliveryPrice = 25 },
                new Address { Id = 11, CityName = "Meet El-Shiokh", DeliveryPrice = 25 },
                new Address { Id = 12, CityName = "El-Nawawra", DeliveryPrice = 25 },
                new Address { Id = 13, CityName = "El-Shata", DeliveryPrice = 25 },
                new Address { Id = 14, CityName = "El-Tabloul", DeliveryPrice = 25 },
                new Address { Id = 15, CityName = "Kafr El-Dawwar", DeliveryPrice = 25 },
                new Address { Id = 16, CityName = "El-Bana", DeliveryPrice = 25 },
                new Address { Id = 17, CityName = "El-Sheikhy", DeliveryPrice = 25 },
                new Address { Id = 18, CityName = "Al-Galala", DeliveryPrice = 25 },
                new Address { Id = 19, CityName = "El-Azab", DeliveryPrice = 25 },
                new Address { Id = 20, CityName = "El-Haraqia", DeliveryPrice = 25 },
                new Address { Id = 21, CityName = "El-Negaila", DeliveryPrice = 25 },
                new Address { Id = 22, CityName = "El-Rahmaniya", DeliveryPrice = 25 },
                new Address { Id = 23, CityName = "Kafr El-Batikh El-Bahary", DeliveryPrice = 25 },
                new Address { Id = 24, CityName = "El-Qarya El-Bayda", DeliveryPrice = 25 },
                new Address { Id = 25, CityName = "El-Safha", DeliveryPrice = 25 },
                new Address { Id = 26, CityName = "El-Maghara", DeliveryPrice = 25 },
                new Address { Id = 27, CityName = "El-Harath", DeliveryPrice = 25 },
                new Address { Id = 28, CityName = "El-Sameil", DeliveryPrice = 25 },
                new Address { Id = 29, CityName = "El-Qasrayn", DeliveryPrice = 25 },
                new Address { Id = 30, CityName = "El-Ghoabeen", DeliveryPrice = 25 },
                new Address { Id = 31, CityName = "Kafr El-Meselha", DeliveryPrice = 25 },
                new Address { Id = 32, CityName = "El-Athar", DeliveryPrice = 25 },
                new Address { Id = 33, CityName = "El-Khashab", DeliveryPrice = 25 },
                new Address { Id = 34, CityName = "El-Seyouf", DeliveryPrice = 25 },
                new Address { Id = 35, CityName = "El-Gendi", DeliveryPrice = 25 },
                new Address { Id = 36, CityName = "El-Saadat", DeliveryPrice = 25 },
                new Address { Id = 37, CityName = "El-Hanout", DeliveryPrice = 25 },
                new Address { Id = 38, CityName = "El-Safira", DeliveryPrice = 25 },
                new Address { Id = 39, CityName = "El-Rouda", DeliveryPrice = 25 },
                new Address { Id = 40, CityName = "El-Mahamid", DeliveryPrice = 25 },
                new Address { Id = 41, CityName = "El-Dammara", DeliveryPrice = 25 },
                new Address { Id = 42, CityName = "El-Ameriya", DeliveryPrice = 25 },
                new Address { Id = 43, CityName = "El-Manshiya", DeliveryPrice = 25 },
                new Address { Id = 44, CityName = "El-Dahab", DeliveryPrice = 25 },
                new Address { Id = 45, CityName = "El-Katiba", DeliveryPrice = 25 },
                new Address { Id = 46, CityName = "El-Qasas", DeliveryPrice = 25 },
                new Address { Id = 47, CityName = "El-Sawalha", DeliveryPrice = 25 },
                new Address { Id = 48, CityName = "El-Matareya", DeliveryPrice = 25 },
                new Address { Id = 49, CityName = "El-Qawafeer", DeliveryPrice = 25 },
                new Address { Id = 50, CityName = "El-Berkit", DeliveryPrice = 25 },
                new Address { Id = 51, CityName = "El-Ebidia", DeliveryPrice = 25 },
                new Address { Id = 52, CityName = "Saad El-Balad", DeliveryPrice = 25 },
                new Address { Id = 53, CityName = "Kafr El-Arab", DeliveryPrice = 25 },
                new Address { Id = 54, CityName = "El-Mattari", DeliveryPrice = 30 },
                new Address { Id = 55, CityName = "El-Senania", DeliveryPrice = 30 }
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

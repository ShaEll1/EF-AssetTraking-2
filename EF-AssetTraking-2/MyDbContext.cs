using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_AssetTraking_2
{
    internal class MyDbContext: DbContext
    {
        string connectionString = "Data Source=DESKTOP-7K830GB;Initial Catalog=AssetTraking2;Integrated Security=True";
        // create a table with the name - Assets

        public DbSet<Office> Offices { get; set; }
        public DbSet<Asset> Assets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // We tell the app to use the connectionstring.
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {

            ModelBuilder.Entity<Office>().HasData(new Office { Id = 1, Name = "USA" });
            ModelBuilder.Entity<Office>().HasData(new Office { Id = 2, Name = "Spain" });
            ModelBuilder.Entity<Office>().HasData(new Office { Id = 3, Name = "Sweden" });

            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 1, AssetType = "Laptop", Brand = "MacBook", PurchaseDate = new DateTime(2019, 5, 20).Date, Price = 1500, OfficeId = 1 });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 2, AssetType = "Laptop", Brand = "Asus", PurchaseDate = new DateTime(2021, 10, 2).Date, Price = 1200, OfficeId = 2 });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 3, AssetType = "Laptop", Brand = "Lenovo", PurchaseDate = new DateTime(2022, 1, 10).Date, Price = 1100, OfficeId = 1 });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 4, AssetType = "Laptop", Brand = "MacBook", PurchaseDate = new DateTime(2023, 9, 30).Date, Price = 5700, OfficeId = 3 });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 5, AssetType = "Laptop", Brand = "Asus", PurchaseDate = new DateTime(2021, 8, 27).Date, Price = 3500, OfficeId = 3 });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 6, AssetType = "Mobile Phone", Brand = "Iphone", PurchaseDate = new DateTime(2019, 12, 20).Date, Price = 800, OfficeId = 2 });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 7, AssetType = "Mobile Phone", Brand = "Samsung", PurchaseDate = new DateTime(2021, 5, 30).Date, Price = 2700, OfficeId = 3 });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 8, AssetType = "Mobile Phone", Brand = "Nokia", PurchaseDate = new DateTime(2019, 12, 20).Date, Price = 500, OfficeId = 1 });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 9, AssetType = "Mobile Phone", Brand = "Iphone", PurchaseDate = new DateTime(2023, 7, 20).Date, Price = 1000, OfficeId = 1 });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 10, AssetType = "Mobile Phone", Brand = "Iphone", PurchaseDate = new DateTime(2021, 12, 02).Date, Price = 3900, OfficeId = 3 });


        }
    }
}

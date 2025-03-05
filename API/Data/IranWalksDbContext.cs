using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class IranWalksDbContext : DbContext
    {
        public IranWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed data for Difficulties table - Easy, Medium, Hard:
            List<Difficulty> difficulties = 
                [
                new Difficulty
                {
                    Id = Guid.Parse("4c0f0e32-38ee-47d0-88e4-acbd9062e8da"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("bb1e5d6f-76d1-4573-9e12-a201e5d576be"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("5cbb6365-1d33-4365-8e98-0d84bef71cb3"),
                    Name = "Hard"
                }
                ];
            // Seed difficulties to the database:
            modelBuilder.Entity<Difficulty>().HasData(difficulties);
            // Seed data for Regions:
            List<Region> regions =
                [
                new Region
                {
                    Id = Guid.Parse("5258c24f-5731-482d-a30a-551d5736987e"),
                    Code = "GRN",
                    Name = "Gorgan",
                    RegionImageUrl = "https://cdn.pixabay.com/photo/2016/11/29/05/45/aerial-1867092_960_720.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("6816a60c-9e51-4218-ae33-41af66a29d2f"),
                    Code = "BJD",
                    Name = "Birjand",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("54193e0d-36b0-4763-81aa-98a09b5a2345"),
                    Code = "THN",
                    Name = "Tehran",
                    RegionImageUrl = "https://cdn.pixabay.com/photo/2016/11/29/05/45/aerial-1867092_960_720.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("f3b3b3b3-1b3b-4b3b-8b3b-3b3b3b3b3b3b"),
                    Code = "SHR",
                    Name = "Shiraz",
                    RegionImageUrl = "https://cdn.pixabay.com/photo/2016/11/29/05/45/aerial-1867092_960_720.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("b3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b"),
                    Code = "KRM",
                    Name = "Kerman",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("a3a3a3a3-3a3a-3a3a-3a3a-3a3a3a3a3a3a"),
                    Code = "RAS",
                    Name = "Rasht",
                    RegionImageUrl = "https://cdn.pixabay.com/photo/2016/11/29/05/45/aerial-1867092_960_720.jpg"
                }
                ];
            // Seed regions to the database:
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}

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
        }
    }
}

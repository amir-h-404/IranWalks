using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class IranWalksDbContext : DbContext
    {
        public IranWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}

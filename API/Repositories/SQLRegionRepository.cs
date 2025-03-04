using API.Data;
using API.Models.Domain;

namespace API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly IranWalksDbContext _dbContext;

        public SQLRegionRepository(IranWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}

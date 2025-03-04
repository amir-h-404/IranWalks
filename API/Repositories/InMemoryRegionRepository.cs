using API.Models.Domain;

namespace API.Repositories
{
    public class InMemoryRegionRepository : IRegionRepository
    {
        public async Task<List<Region>> GetAllAsync()
        {
            return
                [
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Code = "EMD",
                    Name = "Emadi"
                }
                ];
        }
    }
}

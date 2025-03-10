﻿using API.Data;
using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly IranWalksDbContext _dbContext;

        public SQLRegionRepository(IranWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Region?> CreateAsync(Region region)
        {
            var checkRegion = await _dbContext.Regions
                .FirstOrDefaultAsync(x => x.Code.Equals(region.Code) || 
                x.Name.Equals(region.Name));
            if (checkRegion != null) return null;
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var region = await _dbContext.Regions
                .FirstOrDefaultAsync(x => x.Id == id);
            if (region == null) return null;
            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Regions
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingReg = await _dbContext.Regions
                .FirstOrDefaultAsync(x => x.Id == id);
            if (existingReg == null) return null;
            existingReg.Code = region.Code;
            existingReg.Name = region.Name;
            existingReg.RegionImageUrl = region.RegionImageUrl;
            await _dbContext.SaveChangesAsync();
            return existingReg;
        }
    }
}

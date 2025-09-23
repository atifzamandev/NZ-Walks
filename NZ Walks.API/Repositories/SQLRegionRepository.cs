using Microsoft.EntityFrameworkCore;
using NZ_Walks.API.Data;
using NZ_Walks.API.Models.Domain;

namespace NZ_Walks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        public readonly NZWalksDbContext dbContext;
        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<List<Region>> GetAllRegionsAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }
        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Region?> GetRegionByCodeAsync(string code)
        {

            return await dbContext.Regions.FirstOrDefaultAsync(r => r.Code == code);
        }

        public async Task<Region> CreateRegionAsync(Region region)
        {

            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {

            var existingRegin = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

            if (existingRegin == null)
            {
                return null;
            }

            existingRegin.Code = region.Code;
            existingRegin.Name = region.Name;
            existingRegin.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            return existingRegin;
        }

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {

            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

            if (existingRegion == null)
            {
                return null;
            }

            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();

            return existingRegion;

        }

    }
}

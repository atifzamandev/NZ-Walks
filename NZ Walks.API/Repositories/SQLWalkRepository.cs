using Microsoft.EntityFrameworkCore;
using NZ_Walks.API.Data;
using NZ_Walks.API.Models.Domain;

namespace NZ_Walks.API.Repositories
    {
    public class SQLWalkRepository:IWalkRepository
        {
        private readonly NZWalksDbContext dbContext;
        public SQLWalkRepository(NZWalksDbContext dbContext)
            {
            this.dbContext = dbContext;
            }

        public async Task<Walk> CreateWalkAsync(Walk walk)
            {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
            }
        public async Task<List<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterQuery = null)
            {
            var walks = dbContext.Walks
            .Include(x => x.Difficulty)
            .Include("Region").AsQueryable();

            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
                {
                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                    }
                }


            return await walks.ToListAsync();
            /*
            return await dbContext.Walks
                .Include(x => x.Difficulty)
                .Include("Region")
                .ToListAsync();
            */
            }

        public async Task<Walk?> GetWalkByIdAsync(Guid id)
            {
            return await dbContext.Walks
                .Include("Difficulty")
                .Include(x => x.Region)
                .FirstOrDefaultAsync(x => x.Id == id);
            }
        public async Task<Walk?> UpdateWalkAsync(Guid id, Walk walk)
            {

            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if(existingWalk == null)
                {
                return null;
                }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;

            await dbContext.SaveChangesAsync();
            return existingWalk;
            }

        public async Task<Walk?> DeleteWalkAsync(Guid id)
            {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if(existingWalk == null) return null;

            dbContext.Walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();
            return existingWalk;
            }
        }
    }

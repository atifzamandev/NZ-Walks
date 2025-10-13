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
            return walk;
            }
        public async Task<List<Walk>> GetAllWalksAsync()
            {
            return await dbContext.Walks
                .Include(x => x.Difficulty)
                .Include("Region")
                .ToListAsync();
            }
        }
    }

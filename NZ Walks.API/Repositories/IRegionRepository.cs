using NZ_Walks.API.Models.Domain;

namespace NZ_Walks.API.Repositories
    {
    public interface IRegionRepository
        {
        Task<List<Region>> GetAllRegionsAsync();
        Task<Region?> GetRegionByIdAsync(Guid id);

        Task<Region?> GetRegionByCodeAsync(string code);

        Task<Region> CreateRegionAsync(Region region);

        Task<Region?> UpdateRegionAsync(Guid id, Region region);

        Task<Region?> DeleteRegionAsync(Guid id);

        }
    }

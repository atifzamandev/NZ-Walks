using NZ_Walks.API.Models.Domain;

namespace NZ_Walks.API.Repositories
    {
    public interface IWalkRepository
        {
        Task<Walk> CreateWalkAsync(Walk walk);
        }
    }

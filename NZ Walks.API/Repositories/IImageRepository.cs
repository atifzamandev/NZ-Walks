using NZ_Walks.API.Models.Domain;

namespace NZ_Walks.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);

    }
}

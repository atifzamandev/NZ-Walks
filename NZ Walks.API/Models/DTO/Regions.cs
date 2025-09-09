namespace NZ_Walks.API.Models.DTO
{
    public class RegionsDto
    {
        public Guid Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
        public string? RegionImageUrl { get; set; }

    }
}

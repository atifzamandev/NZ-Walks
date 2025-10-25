using System.ComponentModel.DataAnnotations;

namespace NZ_Walks.API.Models.DTO
    {
    public class AddWalkRequestDto
        {
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 character")]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Description should be a maximum of 1000 character")]

        public string Description { get; set; }
        [Required]
        [Range(0, 100)]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid RegionId { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        }
    }

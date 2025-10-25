using System.ComponentModel.DataAnnotations;

namespace NZ_Walks.API.Models.DTO
    {
    public class UpdateRegionRequestDto
        {
        [Required]
        [MinLength(3, ErrorMessage = "Please provide minimum 3 character code")]
        [MaxLength(5, ErrorMessage = "Please provide maximum 5 character code")]
        public required string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 character")]
        public required string Name { get; set; }
        public string? RegionImageUrl { get; set; }
        }
    }

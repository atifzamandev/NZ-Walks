using System.ComponentModel.DataAnnotations;

namespace NZ_Walks.API.Models.DTO
{
    public class LoginReqeustDto
    {

        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

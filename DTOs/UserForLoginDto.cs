using System.ComponentModel.DataAnnotations;

namespace BenefitsManagementAPI.DTOs
{
    public class UserForLoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
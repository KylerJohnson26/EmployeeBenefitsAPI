using System;
using System.ComponentModel.DataAnnotations;

namespace BenefitsManagementAPI.DTOs
{
    public class EmployeeDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public bool IsMale { get; set; }
    }
}
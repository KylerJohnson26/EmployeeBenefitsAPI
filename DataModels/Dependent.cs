using System;
using System.ComponentModel.DataAnnotations;
using BenefitsManagementAPI.DTOs;

namespace BenefitsManagementAPI.DataModels
{
    public class Dependent
    {
        public Dependent(DependentDto dependentDto)
        {
            FirstName = dependentDto.FirstName;
            LastName = dependentDto.LastName;
            DateOfBirth = dependentDto.DateOfBirth;
            DateAdded = DateTime.Now;
            EmployeeId = dependentDto.EmployeeId;
        }

        public Dependent(Dependent dependent)
        {
            FirstName = dependent.FirstName;
            LastName = dependent.LastName;
            DateOfBirth = dependent.DateOfBirth;
            DateAdded = dependent.DateAdded;
            EmployeeId = dependent.EmployeeId;
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
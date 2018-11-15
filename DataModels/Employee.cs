using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BenefitsManagementAPI.DTOs;

namespace BenefitsManagementAPI.DataModels
{
    public class Employee
    {
        public Employee() {}
        public Employee(EmployeeDto employeeDto)
        {
            FirstName = employeeDto.FirstName;
            LastName = employeeDto.LastName;
            DateOfBirth = employeeDto.DateOfBirth;
            DateCreated = DateTime.Now;
            IsActive = true;
            IsMale = employeeDto.IsMale;
            GrossPayPerPeriod = 2000.00m;
            NumPayPeriodsPerYear = 26; 
        }

        public Employee(Employee employee) 
        {
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            DateOfBirth = employee.DateOfBirth;
            DateCreated = employee.DateCreated;
            IsActive = employee.IsActive;
            IsMale = employee.IsMale;
            GrossPayPerPeriod = employee.GrossPayPerPeriod;
            NumPayPeriodsPerYear = employee.NumPayPeriodsPerYear;
        }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsMale { get; set; }
        [Required]
        public decimal GrossPayPerPeriod { get; set; }
        [Required]
        public int NumPayPeriodsPerYear { get; set; }
        public decimal? AnnualCostOfBenefits { get; set; }
        public decimal? CostOfBenefitsPerPayPeriod { get; set; }
        public int? Discount { get; set; }
        public List<Dependent> Dependents { get; set; }
    }
}
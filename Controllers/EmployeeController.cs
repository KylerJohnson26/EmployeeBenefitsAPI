using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenefitsManagementAPI.DataModels;
using BenefitsManagementAPI.DTOs;
using BenefitsManagementAPI.Repositories;
using BenefitsManagementAPI.Services;
using EmployeeBenefitsAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BenefitsManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IBenefitsCalculatorService _benfitsCalcService;
        public EmployeeController(IEmployeeRepository employeeRepository, IBenefitsCalculatorService benefitsCalcService)
        {
            _employeeRepo = employeeRepository;
            _benfitsCalcService = benefitsCalcService;
        }

        // POST /api/employee/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDto employeeDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var employee = new Employee(employeeDto);
            var calculatedBenefits = _benfitsCalcService.Calculate(employee);
            employee.AnnualCostOfBenefits = calculatedBenefits.AnnualCostOfBenefits;
            employee.CostOfBenefitsPerPayPeriod = calculatedBenefits.CostOfBenefitsPerPayPeriod;
            employee.Discount = calculatedBenefits.DiscountPercentage;
            await _employeeRepo.AddNewEmployee(employee);

            return Ok(employee);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveEmployees()
        {
            var employees = await _employeeRepo.GetActiveEmployees();

            var dashboardEmployees = new List<DashboardEmployeeDto>();
            foreach(var empl in employees)
                dashboardEmployees.Add(new DashboardEmployeeDto(
                    empl.EmployeeId,
                    empl.FirstName,
                    empl.LastName,
                    empl.IsMale));

            return Ok(dashboardEmployees);
        }

        // GET /api/employee/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            var employee = await _employeeRepo.GetEmployeeById(id);
            
            if(employee == null)
                return BadRequest("No results found.");

            return Ok(employee);
        }

        // PUT /api/employee/
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Employee editedEmployee) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var calculatedBenefits = _benfitsCalcService.Calculate(editedEmployee);
            editedEmployee.AnnualCostOfBenefits = calculatedBenefits.AnnualCostOfBenefits;
            editedEmployee.CostOfBenefitsPerPayPeriod = calculatedBenefits.CostOfBenefitsPerPayPeriod;
            editedEmployee.Discount = calculatedBenefits.DiscountPercentage;
            await _employeeRepo.EditEmployee(editedEmployee);

            return Ok(editedEmployee);
        }

        // GET /api/employee/deactivate/1
        [HttpGet("deactivate/{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var employee = await _employeeRepo.DeactivateEmployee(id);

            return Ok(employee);
        }

        // GET /api/employee/activate/1
        [HttpGet("activate/{id}")]
        public async Task<IActionResult> Activate(int id)
        {
            var employee = await _employeeRepo.ActivateEmployee(id);

            return Ok(employee);
        }

        // DELETE /api/employee/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeRepo.DeleteEmployee(id);
            
            return Ok();
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenefitsManagementAPI.DataModels;
using BenefitsManagementAPI.DTOs;
using BenefitsManagementAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BenefitsManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepo = employeeRepository;
        }

        // POST /api/employee/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDto employeeDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var employee = new Employee(employeeDto);
            await _employeeRepo.AddNewEmployee(employee);

            return Ok(employee);
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

            await _employeeRepo.EditEmployee(editedEmployee);

            return Ok(editedEmployee);
        }

        // PUT /api/employee/deactivate
        [HttpGet]
        public async Task<IActionResult> Deactivate(int employeeId)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            await _employeeRepo.DeactivateEmployee(employeeId);

            return Ok();
        }

        // DELETE /api/employee/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int employeeId)
        {
            await _employeeRepo.DeleteEmployee(employeeId);
            
            return Ok();
        }
        
    }
}
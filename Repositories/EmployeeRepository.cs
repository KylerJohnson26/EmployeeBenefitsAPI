
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenefitsManagementAPI.Data;
using BenefitsManagementAPI.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BenefitsManagementAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> GetActiveEmployees()
        {
            return await _context.Employees.Where(x => x.IsActive == true)
                .Include(employee => employee.Dependents).ToListAsync();
        }
        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await _context.Employees.Where(x => x.EmployeeId == employeeId)
                .Include(employee => employee.Dependents).SingleOrDefaultAsync();
        }

        public async Task AddNewEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task EditEmployee(Employee editedEmployee)
        {
            _context.Employees.Update(editedEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> DeactivateEmployee(int employeeId)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(x => x.EmployeeId == employeeId);
            employee.IsActive = false;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> ActivateEmployee(int employeeId)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(x => x.EmployeeId == employeeId);
            employee.IsActive = true;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(x => x.EmployeeId == employeeId);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
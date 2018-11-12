
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
        public IEnumerable<Employee> GetActiveEmployees()
        {
            return _context.Employees.Where(x => x.IsActive == true);
        }
        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await _context.Employees.SingleOrDefaultAsync(x => x.EmployeeId == employeeId);
        }

        public async Task AddNewEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task EditEmployee(Employee editedEmployee)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(x => x.EmployeeId == editedEmployee.EmployeeId);

            if(employee != null)
            {
                employee = editedEmployee;
            }

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeactivateEmployee(int employeeId)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(x => x.EmployeeId == employeeId);
            employee.IsActive = false;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(x => x.EmployeeId == employeeId);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
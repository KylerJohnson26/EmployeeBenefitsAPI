using System.Collections.Generic;
using System.Threading.Tasks;
using BenefitsManagementAPI.DataModels;

namespace BenefitsManagementAPI.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetActiveEmployees();
        Task<Employee> GetEmployeeById(int employeeId);
        Task AddNewEmployee(Employee employee);
        Task EditEmployee(Employee editedEmployee);
        Task<Employee> DeactivateEmployee(int employeeId);
        Task<Employee> ActivateEmployee(int employeeId);
        Task DeleteEmployee(int employeeId);
    }
}
using BenefitsManagementAPI.DataModels;
using BenefitsManagementAPI.Models;

namespace BenefitsManagementAPI.Services
{
    public interface IBenefitsCalculatorService
    {
        CalculatedBenefits Calculate(Employee employee);
    }
}
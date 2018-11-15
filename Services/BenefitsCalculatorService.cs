using BenefitsManagementAPI.DataModels;
using BenefitsManagementAPI.Helpers;
using BenefitsManagementAPI.Models;

namespace BenefitsManagementAPI.Services
{
    public class BenefitsCalculatorService : IBenefitsCalculatorService
    {
        private readonly ISettingsHelper _settings;
        public BenefitsCalculatorService(ISettingsHelper settingsHelper)
        {
            _settings = settingsHelper;
        }
        public CalculatedBenefits Calculate(Employee employee)
        {
            decimal costOfBenefits = _settings.GetDefaultBenefitsAnnualCost();
            int percentage = _settings.GetDiscountPercentage();

            // if dependents, additional benefits cost will be incurred - recalc
            if(employee.Dependents.Count > 0) {}
                costOfBenefits = RecalculateCostForDependents(costOfBenefits, employee);
            
            if(IsEligibleForDiscount(employee))
                costOfBenefits = RecalculateCostWithDiscount(costOfBenefits, percentage, employee);

            decimal costPerPayPeriod = costOfBenefits / employee.GrossPayPerPeriod;
            
            CalculatedBenefits calculatedBenefits = new CalculatedBenefits(costOfBenefits, costPerPayPeriod, percentage);
            
            return calculatedBenefits;
        }

        private decimal RecalculateCostForDependents(decimal costOfBenefits, Employee employee)
        {
            decimal additionalCostPerDependent = _settings.GetAdditionalCostPerDependent();
            decimal totalAdditionalCost = employee.Dependents.Count * additionalCostPerDependent;
            return costOfBenefits + totalAdditionalCost;
        }

        private decimal RecalculateCostWithDiscount(decimal costOfBenefits, int percentage, Employee employee)
        {
            decimal percentageFactor = percentage / 100;
            decimal discountAmount = costOfBenefits * percentageFactor;
            return costOfBenefits - discountAmount;
        }

        private bool IsEligibleForDiscount(Employee employee)
        {
            if(employee.FirstName.ToUpper().StartsWith("A"))
                return true;
            return false;
        }
    }
}
using Microsoft.Extensions.Configuration;

namespace BenefitsManagementAPI.Helpers
{
    public class SettingsHelper : ISettingsHelper
    {
        private readonly IConfiguration _config;
        public SettingsHelper(IConfiguration configuration)
        {
            _config = configuration;
        }
        public decimal GetDefaultPayPerPeriod()
        {
            decimal defaultPayPerPeriod;
            var defaultPay = _config.GetSection("EmployeeDefaults:DefaultPayPerPeriod").Value;
            decimal.TryParse(defaultPay, out defaultPayPerPeriod);

            return defaultPayPerPeriod;
        }

        public int GetNumPayPeriodsPerYear()
        {
            int numPayPeriodsPerYear;
            var defaultStr = _config.GetSection("EmployeeeDefaults:DefaultNumPayPeriodsPerYear").Value;
            int.TryParse(defaultStr, out numPayPeriodsPerYear);

            return numPayPeriodsPerYear;
        }

        public string GetAuthKey()
        {
            return _config.GetSection("AppSettings:AuthKey").Value;
        }

        public decimal GetDefaultBenefitsAnnualCost()
        {
            decimal defaultAnnualCost;
            var defaultCost = _config.GetSection("EmployeeDefaults:AnnualCostOfBenefits").Value;
            decimal.TryParse(defaultCost, out defaultAnnualCost);

            return defaultAnnualCost;
        }

        public decimal GetAdditionalCostPerDependent()
        {
            decimal additionalCost;
            var defaultCost = _config.GetSection("EmployeeDefaults:AdditionalCostPerDependent").Value;
            decimal.TryParse(defaultCost, out additionalCost);

            return additionalCost;
        }

        public int GetDiscountPercentage()
        {
            int percentage;
            var defaultPercentage = _config.GetSection("EmployeeDefaults:BenefitDiscountPercentage").Value;
            int.TryParse(defaultPercentage, out percentage);

            return percentage;
        }
    }
}
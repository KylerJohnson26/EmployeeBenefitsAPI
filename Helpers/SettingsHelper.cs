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
    }
}
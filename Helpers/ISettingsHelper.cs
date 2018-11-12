namespace BenefitsManagementAPI.Helpers
{
    public interface ISettingsHelper
    {
         decimal GetDefaultPayPerPeriod();
         int GetNumPayPeriodsPerYear();
    }
}
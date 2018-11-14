namespace BenefitsManagementAPI.Helpers
{
    public interface ISettingsHelper
    {
        string GetAuthKey();
        decimal GetDefaultPayPerPeriod();
        int GetNumPayPeriodsPerYear();
    }
}
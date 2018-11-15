namespace BenefitsManagementAPI.Helpers
{
    public interface ISettingsHelper
    {
        string GetAuthKey();
        decimal GetDefaultPayPerPeriod();
        int GetNumPayPeriodsPerYear();
        decimal GetDefaultBenefitsAnnualCost();
        decimal GetAdditionalCostPerDependent();
        int GetDiscountPercentage();
    }
}
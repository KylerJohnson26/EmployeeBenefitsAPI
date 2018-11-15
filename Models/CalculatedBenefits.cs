namespace BenefitsManagementAPI.Models
{
    public class CalculatedBenefits
    {
        public CalculatedBenefits(decimal costOfBenefits, decimal costPerPayPeriod, int percentage)
        {
            AnnualCostOfBenefits = costOfBenefits;
            CostOfBenefitsPerPayPeriod = costPerPayPeriod;
            DiscountPercentage = percentage;
        }
        public decimal AnnualCostOfBenefits { get; set; }
        public decimal CostOfBenefitsPerPayPeriod { get; set; }
        public int DiscountPercentage { get; set; }
    }
}
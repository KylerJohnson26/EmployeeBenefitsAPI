namespace EmployeeBenefitsAPI.DTOs
{
    public class DashboardEmployeeDto
    {
        public DashboardEmployeeDto(int empoyeeId, string firstName, string lastName, bool isMale)
        {
            EmployeeId = empoyeeId;
            FirstName = firstName;
            LastName = lastName;
            IsMale = isMale;
        }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMale { get; set; }
    }
}
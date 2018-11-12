using BenefitsManagementAPI.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BenefitsManagementAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
    }
}
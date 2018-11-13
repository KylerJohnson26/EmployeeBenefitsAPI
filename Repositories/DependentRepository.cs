using System.Linq;
using System.Threading.Tasks;
using BenefitsManagementAPI.Data;
using BenefitsManagementAPI.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BenefitsManagementAPI.Repositories
{
    public class DependentRepository : IDependentRepository
    {
        private readonly DataContext _context;
        public DependentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddNewDependent(Dependent dependent)
        {
            _context.Dependents.Add(dependent);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveDependent(int dependentId)
        {
            var dependent = await _context.Dependents.SingleOrDefaultAsync(x => x.Id == dependentId);
            _context.Dependents.Remove(dependent);
            await _context.SaveChangesAsync();
        }

        public async Task EditDependent(Dependent editedDependent)
        {
            _context.Dependents.Update(editedDependent);
            await _context.SaveChangesAsync();
        }
    }
}
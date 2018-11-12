using System.Threading.Tasks;
using BenefitsManagementAPI.DataModels;

namespace BenefitsManagementAPI.Repositories
{
    public interface IDependentRepository
    {
         Task AddNewDependent(Dependent dependent);
         Task RemoveDependent(int dependentId);
         Task UpdateDependent(Dependent editedDependent);
    }
}
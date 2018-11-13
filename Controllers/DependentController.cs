using System.Threading.Tasks;
using BenefitsManagementAPI.DataModels;
using BenefitsManagementAPI.DTOs;
using BenefitsManagementAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BenefitsManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class DependentController : ControllerBase
    {
        private readonly IDependentRepository _dependentRepo;
        public DependentController(IDependentRepository dependentRepository)
        {
            _dependentRepo = dependentRepository;
        }
        
        // POST /api/dependent/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DependentDto dependentDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var newDependent = new Dependent(dependentDto);
            await _dependentRepo.AddNewDependent(newDependent);
            
            return Ok(newDependent);
        }

        // POST /api/dependent/
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Dependent dependent)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            await _dependentRepo.EditDependent(dependent);

            return Ok(dependent);
        }

        // POST /api/dependent/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dependentRepo.RemoveDependent(id);
            
            return Ok();
        }
    }
}
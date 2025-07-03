using Inventory_LIB.Models;
using Inventory_LIB.Repositories.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyBranchController : ControllerBase
    {
        private IUnitOFWork _unitOFWork;
        public CompanyBranchController(IUnitOFWork unitOFWork)
        {
            _unitOFWork = unitOFWork;
        }
        public async Task<List<CompanyBranch>> Get()
        {
            var data = await _unitOFWork.CompanyBranchRepo.GetAll(null, null);
            return data.ToList();
        }
        [HttpPost]
        public async Task<IActionResult> Post(CompanyBranch entity)
        {
            entity.CreatedBy = User.Identity?.Name?? "Not authenticated";
            entity.CreatedDate = DateTime.Now.Date;
            entity.IsActive =true;
            await _unitOFWork.CompanyBranchRepo.Add(entity);
            _unitOFWork.Save();
            return Created("", entity);

        }
    }
}

using Inventory_LIB.Models;
using Inventory_LIB.Repositories.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyInfosController : ControllerBase
    { 
        private IUnitOFWork _unitOFWork;
        public CompanyInfosController(IUnitOFWork unitOFWork)
        {
            _unitOFWork = unitOFWork;
        }
        [HttpGet]
        public async Task<List<CompanyInfo>> Get()
        {
            var data= await _unitOFWork.CompanyRepo.GetAll(null,null);
            return data.ToList();
        }
        [HttpPost]
        public async Task<IActionResult > Post(CompanyInfo entity)
        {
             await _unitOFWork.CompanyRepo.Add(entity);
            _unitOFWork.Save();
            return Created("", entity);
         
        }
    }
}

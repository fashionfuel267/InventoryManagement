using Inventory_LIB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public AuthenticateController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
            
        }
        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUser entity)
        {
            var insertUser = new ApplicationUser
            {
                UserName = entity.UserName,
                PhoneNumber=entity.PhoneNumber,
                Email=entity.Email
            };
       var result =  await   _userManager.CreateAsync(insertUser,entity.PasswordHash);
            if(result.Succeeded)
            {
                return Created("", entity);
            }
            else if(result.Errors.Count()>0)
            {
                string msg = string.Join(",", result.Errors.Select(e => $"{e.Code} - {e.Description}"));
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = msg });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unknow error!" });
            }

        }
    }
}

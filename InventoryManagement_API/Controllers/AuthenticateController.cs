using Inventory_LIB.Models;
 
using InventoryManagement_API.DTOs;
using InventoryManagement_API.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Data;
using System.Security.Claims;
using System.Text;

namespace InventoryManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private ITokenManager _tokenManager;
        public AuthenticateController(UserManager<ApplicationUser> userManager ,ITokenManager tokenManager)
        {
            this._userManager = userManager;
            this._tokenManager = tokenManager;
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO entity)
        {
            if (entity == null)
            {
                return BadRequest(new { message = "Please provide username  Password" });
            }
            try
            {


                //// Decode the password hash if it exists
                //if (!string.IsNullOrEmpty(entity.Hash))
                //{
                //  //  entity.Password = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(entity.Hash));

                //   var e  = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(entity.Hash));
                //    entity.Password = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(e));

                //}

                // Check if the user exists
                var existUser = await _userManager.FindByNameAsync(entity.UserName);
                if (existUser is null)
                {
                    return Unauthorized(new { msg = "Invalid user name" });
                }
                // Validate the password
                var isValidPassword = await _userManager.CheckPasswordAsync(existUser, entity.Hash);
                if (!isValidPassword)
                {
                    return Unauthorized(new { msg = "Invalid  password" });
                }

                // Generate claims for the token
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, entity.UserName ?? ""),
                    };

                // Generate JWT access token and refresh token
                string accessToken = _tokenManager.GenerateAccessToken(claims);
               if(!String.IsNullOrEmpty(accessToken))
                {
                    return Ok(new { accessToken });
                }
               
            }
            catch(Exception ex)
            {
                return Unauthorized(new { msg = ex.Message });
            }
            return Unauthorized(new {msg= "Unable to auhtentiate"});

            }

    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSE.Identidade.API.Models;

namespace NSE.Identidade.API.Controllers
{
    [Route("api/identity")]
    public class AuthController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;


        public AuthController(  SignInManager<IdentityUser> signInManager,
                                    UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("create-account")]
        public async Task<ActionResult> RegisterUser(UserRegister userRegister)
        {

            if (!ModelState.IsValid) return BadRequest();

            var user = new IdentityUser
            {
                UserName = userRegister.Email,
                Email = userRegister.Email,
                EmailConfirmed = true
            };


            var result = await _userManager.CreateAsync(user, userRegister.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Ok();    
            }

            return BadRequest();

        }

        [HttpPost("sign-in")]
        public async Task<ActionResult> LoginUser(UserLogin userLogin)
        {

            if (!ModelState.IsValid) return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);
            
            if (result.Succeeded)
            { 
                return Ok();
            }

            return BadRequest();
        }
    }
}

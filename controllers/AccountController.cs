using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using testsite.Infactructure;

namespace mysite.controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
        }
        // GET
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn()
        {
                return View();
        }

        // POST
        /*[HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn()
        {
            return View();
        }*/

        // GET
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await _signinManager.SignOutAsync();
            return RedirectToPage("/");
        }
        
        // GET
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            return View();
        }

        // POST
        /*[HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp()
        {
            return View();
        }*/
    }
}
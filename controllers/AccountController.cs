using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using testsite.Infactructure;
using testsite.models.views.account;

namespace testsite.controllers
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
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            return View();
        }

        // POST
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid) {
                var result = await _signinManager.PasswordSignInAsync(
                    model.Username, model.Password, 
                    model.Remember, lockoutOnFailure: false);
                    if (!result.Succeeded) {
                        ModelState.AddModelError(string.Empty, "Invalid login or password.");
                        return View(model);
                    }
                    return RedirectToPage("/");
            }
            return View(model);
        }

        // GET
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToPage("/");
        }
        
        // GET
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        // POST
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid) {
                AppUser user = new AppUser{ UserName = model.Username, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded) {
                    AppendErrors(ref result);
                    return View(model);
                }
                await _signinManager.SignInAsync(user, false);
                return RedirectToPage("/");
            }
            return View(model);
        }

        private void AppendErrors(ref IdentityResult result)
        {
            foreach(var err in result.Errors) {
                ModelState.AddModelError("", err.Description);
            }
        }
    }
}
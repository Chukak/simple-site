using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using testsite.Infactructure;
using testsite.models.views.manage;

namespace testsite.controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ManageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;

        public ManageController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> Account()
        {
            AppUser user = await GetUserAsync();
            var model = new AccountModel
            { 
                Email = user.Email, Username = user.UserName 
            };
            return View(model);
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            if (!await _userManager.HasPasswordAsync(GetUserAsync().Result)) {
                // todo
            }
            var model = new ChangePasswordModel{};
            return View(model);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid) {
                AppUser user = GetUserAsync().Result;
                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded) {
                    AppendErrors(ref result);
                    return View(model);
                }
                await _signinManager.SignInAsync(user, false);
                return RedirectToAction("Account", "Manage");
            }
            return View(model);
        }

        // GET
        public async Task<IActionResult> ChangeUsername()
        {
            AppUser user = await GetUserAsync();
            var model = new ChangeUsernameModel
            {
                CurrentUsername = user.UserName
            };
            // todo
            return View(model);
        }

        // POST
        public async Task<IActionResult> ChangeUsername(ChangeUsernameModel model)
        {
            if (ModelState.IsValid) {
                AppUser user = await GetUserAsync();
                user.UserName = model.NewUsername;
                return RedirectToAction("Account", "Manage");
            }
            return View(model);
        }

        private async Task<AppUser> GetUserAsync()
        {
            AppUser user = await _userManager.GetUserAsync(User);
            if (user == null) {
                throw new ApplicationException($"User load error. Id: '{_userManager.GetUserId(User)}'");
            }
            return user;
        }

        private void AppendErrors(ref IdentityResult result)
        {
            foreach(var err in result.Errors) {
                ModelState.AddModelError("", err.Description);
            }
        }
    }
}
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace mysite.controllers
{
    public class AccountController : Controller
    {
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
            // todo
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
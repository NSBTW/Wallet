using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wallet.Database.Models;
using Wallet.ViewModels;

namespace Wallet.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly UserManager<UserRecord> _userManager;
        private readonly SignInManager<UserRecord> _signInManager;

        public UserController(UserManager<UserRecord> userManager, SignInManager<UserRecord> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet("register")]
        public IActionResult Register() => View();

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterRequest model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new UserRecord {UserName = model.Login};
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Redirect("~/account");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet("login")]
        public IActionResult Login() => View();

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginRequest model)
        {
            if (!ModelState.IsValid) return View(model);
            var result = await _signInManager
                .PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);
            if (result.Succeeded)
                return Redirect("~/account");

            ModelState.AddModelError("", "Incorrect password or login");
            return View(model);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task Logout() => await _signInManager.SignOutAsync();
    }
}
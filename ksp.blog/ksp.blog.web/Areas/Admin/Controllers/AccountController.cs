using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ksp.blog.membership.Services;
using ksp.blog.web.Areas.Admin.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ksp.blog.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly SignInManager _signInManager;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(SignInManager signInManager,
            UserManager userManager,
            RoleManager roleManager,
            ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateAccountViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(nameof(CreateAccountViewModel.UserName),
                                       nameof(CreateAccountViewModel.Email),
                                       nameof(CreateAccountViewModel.Password),
                                       nameof(CreateAccountViewModel.ConfirmPassword))]CreateAccountViewModel model)
        {
            try
            {
                model.CreateAccount();
                _logger.LogInformation("User account created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured");
            }

            model = new CreateAccountViewModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginAccountViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                return RedirectToAction("index", "home");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
             await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");

            return RedirectToAction("index", "home");
        }
    }
}

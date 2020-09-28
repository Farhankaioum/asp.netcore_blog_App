using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ksp.blog.membership;
using ksp.blog.membership.Services;
using ksp.blog.web.Areas.Admin.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
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
        private readonly IMailService _mailService;

        public AccountController(SignInManager signInManager,
            UserManager userManager,
            RoleManager roleManager,
            ILogger<AccountController> logger,
            IMailService mailService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _mailService = mailService;
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

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return View("ResetPasswordMessage");
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var url = Url.Action("ResetPassword", "Account", new { userId = user.Id, code}, Request.Scheme, Request.Host.ToString());

            var mailRequest = new MailRequest
            {
                ToEmail = model.Email,
                Subject = "Password reset link",
                Body = $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(url)}'>Clicking here </a>."
            };

            await _mailService.SendEmailAsync(mailRequest);

            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string code)
        {
            var model = new ResetPasswordViewModel
            {
                Code = code,
                UserId = userId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword([Bind(nameof(ResetPasswordViewModel.UserId),
                                                        nameof(ResetPasswordViewModel.Code),
                                                        nameof(ResetPasswordViewModel.Password),
                                                        nameof(ResetPasswordViewModel.ConfirmPassword))] ResetPasswordViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
                return View();

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }


    }
}

using ksp.blog.membership;
using ksp.blog.membership.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ksp.blog.web.Areas.Admin.Models.Account
{
    public class CreateAccountViewModel : AccountBaseModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        public CreateAccountViewModel(IMembershipService membershipService)
            :base(membershipService) { }
        public CreateAccountViewModel() : base() {  }

        public void CreateAccount()
        {
            var user = new RegistrationModel
            {
                UserName = this.UserName,
                Email = this.Email,
                Password = this.Password
            };

            _membershipService.Registration(user);
        }
    }
}

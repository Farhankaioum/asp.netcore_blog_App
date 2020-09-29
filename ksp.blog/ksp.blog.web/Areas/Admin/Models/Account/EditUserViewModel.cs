using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ksp.blog.web.Areas.Admin.Models.Account
{
    public class EditUserViewModel : FileUploadBaseModel
    {
        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DisplayName("Phone")]
        public string PhoneNumber { get; set; }

        public string ExistingPhotoPath { get; set; }
    }
}

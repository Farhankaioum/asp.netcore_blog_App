using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ksp.blog.web.Areas.Admin.Models.Account
{
    public class FileUploadBaseModel
    {
        public IFormFile  File { get; set; }
    }
}

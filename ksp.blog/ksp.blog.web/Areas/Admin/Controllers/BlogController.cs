using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ksp.blog.web.Areas.Admin.Models;
using ksp.blog.web.Areas.Admin.Models.BlogViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ksp.blog.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new BlogAddViewModel();
            model.LoadCategories();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(BlogAddViewModel model)
        {
            try
            {
                model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                model.CreateBlog();

                model.Response = new ResponseModel("Blog creation successfull!", ResponseType.Success);

                return RedirectToAction("Index", "Category");
            }
            catch (Exception ex)
            {
                model.Response = new ResponseModel("Blog creation failed!", ResponseType.Failure);
                _logger.LogError(ex, "An error occure when insert the blog");
            }

            return View(model);
        }

    }
}

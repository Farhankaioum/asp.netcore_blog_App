using System;
using System.Security.Claims;
using Autofac;
using ksp.blog.web.Areas.Admin.Models;
using ksp.blog.web.Areas.Admin.Models.BlogViewModel;
using ksp.blog.web.Models;
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
            var model = Startup.AutofacContainer.Resolve<BlogIndexViewModel>();
            return View(model);
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

                return RedirectToAction("Index", "Blog");
            }
            catch (Exception ex)
            {
                model.Response = new ResponseModel("Blog creation failed!", ResponseType.Failure);
                _logger.LogError(ex, "An error occure when insert the blog");
            }


            model.LoadCategories();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new BlogEditViewModel();
            model.LoadBlog(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BlogEditViewModel model)
        {
            try
            {

                model.EditBlog();

                model.Response = new ResponseModel("Blog edit successfull!", ResponseType.Success);

                return RedirectToAction("Index", "Blog");
            }
            catch (Exception ex)
            {
                model.Response = new ResponseModel("Blog edit failed!", ResponseType.Failure);
                _logger.LogError(ex, "An error occure when insert the blog");
            }

            
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var model = new BlogDeleteViewModel();
            try
            {
                var title = model.DeleteBlog(id);
                model.Response = new ResponseModel($"Blog {title} successfully deleted.", ResponseType.Success);
                return RedirectToAction("Index", "Blog");
            }
            catch (Exception ex)
            {
                model.Response = new ResponseModel($"Blog delete failed.", ResponseType.Failure);
                _logger.LogError(ex, "An error occured when deleted the book");
            }

            return RedirectToAction("Index", "Blog");

        }

        public IActionResult GetBlogs()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<BlogIndexViewModel>();
            var data = model.GetBlogs(tableModel);
            return Json(data);
        }

    }
}

using System;
using ksp.blog.web.Areas.Admin.Models;
using ksp.blog.web.Areas.Admin.Models.CategoryViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ksp.blog.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new IndexCategoryViewModel();
            model.LoadAllCategories();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateCategoryViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryViewModel model)
        {
            try
            {
                model.CreateCategory();

                model.Response = new ResponseModel("Category creating successfull", ResponseType.Success);

                _logger.LogInformation("Category created");

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                model.Response = new ResponseModel("Category creating failed", ResponseType.Failure);

                _logger.LogError(ex + " Error occured");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new EditCategoryViewModel();
            model.LoadCategoryById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditCategoryViewModel model)
        {
            try
            {
                model.EditCategory();

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = new DeleteCategoryViewModel();
                model.DeleteCategory(id);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured!");
            }

            return View();
        }

    }
}

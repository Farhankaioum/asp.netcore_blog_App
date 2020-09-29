using Autofac;
using ksp.blog.framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ksp.blog.web.Areas.Admin.Models.CategoryViewModel
{
    public class BaseCategoryViewModel
    {
        protected readonly ICategoryService _categoryService;

        public BaseCategoryViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public BaseCategoryViewModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }
    }
}

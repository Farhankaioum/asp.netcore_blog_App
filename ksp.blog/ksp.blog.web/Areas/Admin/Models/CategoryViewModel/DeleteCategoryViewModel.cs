using ksp.blog.framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ksp.blog.web.Areas.Admin.Models.CategoryViewModel
{
    public class DeleteCategoryViewModel : BaseCategoryViewModel
    {

        public DeleteCategoryViewModel(ICategoryService categoryService)
            : base(categoryService)
        {

        }

        public DeleteCategoryViewModel()
            : base()
        {

        }

        public void DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
        }

      
    }
}

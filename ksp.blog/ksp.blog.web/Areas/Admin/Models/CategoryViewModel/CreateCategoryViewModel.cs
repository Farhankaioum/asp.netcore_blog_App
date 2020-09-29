using ksp.blog.framework;
using ksp.blog.framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ksp.blog.web.Areas.Admin.Models.CategoryViewModel
{
    public class CreateCategoryViewModel : BaseCategoryViewModel
    {
        [Required]
        public string Name { get; set; }

        public CreateCategoryViewModel(ICategoryService categoryService)
            : base(categoryService)  { }

        public CreateCategoryViewModel() : base() { }

        public void CreateCategory()
        {
            var category = new Category
            {
                Name = this.Name
            };

            _categoryService.CreateCategory(category);
        }

    }
}

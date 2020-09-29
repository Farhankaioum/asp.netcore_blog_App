using ksp.blog.framework;
using ksp.blog.framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ksp.blog.web.Areas.Admin.Models.CategoryViewModel
{
    public class EditCategoryViewModel : BaseCategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public EditCategoryViewModel(ICategoryService categoryService)
            : base(categoryService)
        { 
        }
        public EditCategoryViewModel()
            : base()
        {

        }

        public void EditCategory()
        {
            var category = new Category
            {
                Id = this.Id,
                Name = this.Name
            };

            _categoryService.EditCategory(category);
        }

        public void LoadCategoryById(int id)
        {
            var category = _categoryService.GetCategory(id);

            if(category != null)
            {
                Id = category.Id;
                Name = category.Name;
            }
        }


    }
}

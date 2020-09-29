using ksp.blog.framework;
using ksp.blog.framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ksp.blog.web.Areas.Admin.Models.CategoryViewModel
{
    public class IndexCategoryViewModel : BaseCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<IndexCategoryViewModel> Categories { get; set; }


        public IndexCategoryViewModel(ICategoryService categoryService)
            : base(categoryService)
        {

        }

        public IndexCategoryViewModel()
            : base()
        {

        }

        public void LoadAllCategories()
        {
           var categories = _categoryService.GetCategories();

            Categories = new List<IndexCategoryViewModel>();

            foreach (var category in categories)
            {
                var newCategory = new IndexCategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                };

                Categories.Add(newCategory);
            }

        }
    }
}

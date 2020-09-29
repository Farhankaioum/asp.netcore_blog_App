using ksp.blog.framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ksp.blog.framework
{
    public interface ICategoryService : IDisposable
    {
        IList<Category> GetCategories();
        Category GetCategory(int id);
        void CreateCategory(Category category);
        void EditCategory(Category category);
        Category DeleteCategory(int id);

    }
}

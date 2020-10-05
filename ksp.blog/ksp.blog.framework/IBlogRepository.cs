using ksp.blog.data;
using ksp.blog.framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ksp.blog.framework
{
    public interface IBlogRepository : IRepository<Blog, int, FrameworkContext>
    {
        void AddBlogCategories(BlogCategory blogCategory);
        Blog FindBlogWithProperties(int id);
        List<int> BlogCategoriesIds(int blogId);
    }
}

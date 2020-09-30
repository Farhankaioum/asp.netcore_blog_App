using ksp.blog.data;
using ksp.blog.framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ksp.blog.framework
{
    public class BlogRepository : Repository<Blog, int, FrameworkContext>, IBlogRepository
    {
        public BlogRepository(FrameworkContext context)
            : base(context)
        {
           
        }

        public void AddBlogCategories(BlogCategory blogCategory)
        {
            _dbContext.BlogCategories.Add(blogCategory);
        }
    }
}

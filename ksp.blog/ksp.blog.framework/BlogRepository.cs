using ksp.blog.data;
using ksp.blog.framework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // for testing purpose
        public Blog FindBlogWithProperties(int id)
        {
            var value = _dbContext.Blogs.Include(c => c.BlogCategories).FirstOrDefault(b => b.Id == id);
           
            return value;
        }

        public List<int> BlogCategoriesIds(int blogId)
        {
            List<int> listOfCategoriesIds = new List<int>();
            var categories = _dbContext.BlogCategories.Include(c => c.Category).Where(c => c.BlogId == blogId);

            foreach (var category in categories)
            {
                listOfCategoriesIds.Add(category.CategoryId);
            }

            return listOfCategoriesIds;

        }

        
    }
}

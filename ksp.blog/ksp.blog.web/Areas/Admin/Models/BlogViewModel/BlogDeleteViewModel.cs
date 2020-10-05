using ksp.blog.framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ksp.blog.web.Areas.Admin.Models.BlogViewModel
{
    public class BlogDeleteViewModel : BlogBaseModel
    {
        public BlogDeleteViewModel(IBlogService blogService)
            : base(blogService) { }

        public BlogDeleteViewModel()
            : base() { }

        public string DeleteBlog(int id)
        {
            var deleteBlog = _blogService.DeleteBlog(id);
            return deleteBlog.Title;
        }
    }
}

using Autofac;
using ksp.blog.framework;

namespace ksp.blog.web.Areas.Admin.Models.BlogViewModel
{
    public class BlogBaseModel : AdminBaseModel
    {
        protected readonly IBlogService _blogService;

        public BlogBaseModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public BlogBaseModel()
        {
            _blogService = Startup.AutofacContainer.Resolve<IBlogService>();
        }
    }
}

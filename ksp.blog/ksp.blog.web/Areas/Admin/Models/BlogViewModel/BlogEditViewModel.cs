using ksp.blog.framework;
using ksp.blog.framework.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ksp.blog.web.Areas.Admin.Models.BlogViewModel
{
    public class BlogEditViewModel : BlogBaseModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public List<int> CategoryIds { get; set; }

        public List<Category> Categories { get; set; }

        public BlogEditViewModel(IBlogService blogService)
            : base(blogService) { }

        public BlogEditViewModel()
            : base() { }

        public void LoadBlog(int id)
        {
            var blog = _blogService.GetBlog(id);
            

           Categories = _blogService.GetCategories();
            
            if (blog != null)
            {
                Id = blog.Id;
                Title = blog.Title;
                Description = blog.Description;
                CategoryIds = _blogService.GetBlogCategoriesId(id);
                
            }
        }

        public void EditBlog()
        {
            var blog = new Blog
            {
                Id = this.Id,
                Title = this.Title,
                Description = this.Description
            };

            _blogService.EditBlog(blog, CategoryIds);
        }

    }
}

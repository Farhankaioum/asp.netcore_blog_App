using ksp.blog.framework;
using ksp.blog.framework.Domain;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ksp.blog.web.Areas.Admin.Models.BlogViewModel
{
    public class BlogAddViewModel : BlogBaseModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public List<int> CategoryIds { get; set; }

        public string UserId { get; set; }

        public List<Category> Categories { get; set; }

        public BlogAddViewModel(IBlogService blogService)
            : base(blogService)
        { }
        public BlogAddViewModel()
            : base()
        { }

        public void CreateBlog()
        {
            var blog = new Blog
            {
                Title = this.Title,
                Description = this.Description,
                PublishDate = DateTime.Now,
                AuthorId = UserId
            };

            _blogService.CreateBlog(blog, CategoryIds);
        }

        public void LoadCategories()
        {
            Categories = _blogService.GetCategories();
        }

    }
}

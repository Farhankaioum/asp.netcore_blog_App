using ksp.blog.framework.CustomException;
using ksp.blog.framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ksp.blog.framework
{
    public class BlogService : IBlogService
    {
        private readonly IBlogUnitOfWork _blogUnitOfWork;

        public BlogService(IBlogUnitOfWork blogUnitOfWork)
        {
            _blogUnitOfWork = blogUnitOfWork;
        }


        public (IList<Blog> records, int total, int totalDisplay) GetBlogs(int pageIndex, int pageSize, string searchText, string sortText)
        {
            throw new NotImplementedException();
        }

        public Blog GetBlog(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateBlog(Blog blog, List<int> categorisId)
        {
            var duplicateCheck = IsDuplicateTitle(blog.Title);

            if (duplicateCheck)
            {
                throw new DuplicationException("Title already exists.", nameof(blog.Title));
            }

            _blogUnitOfWork.BlogRepository.Add(blog);

            for (int i = 0; i < categorisId.Count; i++)
            {
                var blogCategory = new BlogCategory
                {
                    Blog = blog,
                    CategoryId = categorisId[i]
                };

                _blogUnitOfWork.BlogRepository.AddBlogCategories(blogCategory);
            }

            _blogUnitOfWork.Save();
        }

        public void EditBlog(Blog blog)
        {
            var duplicateCheckByTitle = IsDuplicateTitle(blog.Title);
            var duplicateCheckById = _blogUnitOfWork.BlogRepository.GetCount(b => b.Id != blog.Id);

            if (duplicateCheckByTitle && duplicateCheckById > 0)
            {
                throw new DuplicationException("Title already exists.", nameof(blog.Title));
            }

            //var existingBlog = _blogUnitOfWork.BlogRepository.GetById(blog.Id);
            //existingBlog.Title = blog.Title;
            //existingBlog.Description = blog.Description;

            _blogUnitOfWork.BlogRepository.Edit(blog);
            _blogUnitOfWork.Save();
            
        }

        public Blog DeleteBlog(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _blogUnitOfWork?.Dispose();
        }

        public List<Category> GetCategories()
        {
            return _blogUnitOfWork.CategoryRepository.GetAll().ToList();
        }

        private bool IsDuplicateTitle(string title)
        {
           var count = _blogUnitOfWork.BlogRepository.GetCount(b => b.Title == title);

            return count > 0;
        }
    }
}

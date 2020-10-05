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
           var result = _blogUnitOfWork.BlogRepository.Get(s => s.Title.Contains(searchText) || s.Description.Contains(searchText),
                s => s.OrderBy(p => p.Title),
                pageIndex: pageIndex, pageSize: pageSize);

            return (result.data, result.total, result.totalDisplay);

        }

        public Blog GetBlog(int id)
        {
            return _blogUnitOfWork.BlogRepository.GetById(id);
        }

        // Obsolate
        public Blog GetBlogWithNavigationProperty(int id)
        {
            return _blogUnitOfWork.BlogRepository.FindBlogWithProperties(id);
        }

        public List<int> GetBlogCategoriesId(int id)
        {
            return _blogUnitOfWork.BlogRepository.BlogCategoriesIds(id);
        }

        public void CreateBlog(Blog blog, List<int> categorisId)
        {
            var duplicateCheck = IsDuplicateTitle(blog.Title);

            if (duplicateCheck)
            {
                throw new DuplicationException("Title already exists.", nameof(blog.Title));
            }

            _blogUnitOfWork.BlogRepository.Add(blog);

            CategoriesAdd(categorisId, blog);

            _blogUnitOfWork.Save();
        }

        public void EditBlog(Blog blog, List<int> categorisId)
        {
            var duplicateCheckByTitle = IsDuplicateTitle(blog.Title);
            var duplicateCheckById = _blogUnitOfWork.BlogRepository.GetCount(b => b.Id != blog.Id);

            if (duplicateCheckByTitle && duplicateCheckById > 0)
            {
                throw new DuplicationException("Title already exists.", nameof(blog.Title));
            }

            var existingBlog = _blogUnitOfWork.BlogRepository.GetById(blog.Id);
            existingBlog.Title = blog.Title;
            existingBlog.Description = blog.Description;

            EditCategoriesForBlog(categorisId, existingBlog);

            _blogUnitOfWork.Save();
            
        }

        public Blog DeleteBlog(int id)
        {
            var existingBlog = _blogUnitOfWork.BlogRepository.GetById(id);

             _blogUnitOfWork.BlogRepository.Remove(existingBlog);
            _blogUnitOfWork.Save();

            return existingBlog;
        }

        public void Dispose()
        {
            _blogUnitOfWork?.Dispose();
        }

        public List<Category> GetCategories()
        {
            return _blogUnitOfWork.CategoryRepository.GetAll().ToList();
        }

        public List<int> BlogCategoriesId(int blogId)
        {
            return new List<int>();
        }

        private void CategoriesAdd(List<int> categoriesId, Blog blog)
        {
            for (int i = 0; i < categoriesId.Count; i++)
            {
                    var blogCategory = new BlogCategory
                    {
                        Blog = blog,
                        CategoryId = categoriesId[i]
                    };

                    _blogUnitOfWork.BlogRepository.AddBlogCategories(blogCategory);  
            }
        }

        private void EditCategoriesForBlog(List<int> categoriesId, Blog blog)
        {
            blog.BlogCategories.RemoveAll(c => c.BlogId == blog.Id);
            _blogUnitOfWork.Save();

            CategoriesAdd(categoriesId, blog);
        }

        private bool IsDuplicateTitle(string title)
        {
           var count = _blogUnitOfWork.BlogRepository.GetCount(b => b.Title == title);

            return count > 0;
        }
    }
}

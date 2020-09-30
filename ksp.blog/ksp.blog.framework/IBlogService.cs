﻿using ksp.blog.framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ksp.blog.framework
{
    public interface IBlogService : IDisposable
    {
        (IList<Blog> records, int total, int totalDisplay) GetBlogs
            (int pageIndex, int pageSize,
            string searchText, string sortText);
        Blog GetBlog(int id);
        void CreateBlog(Blog blog, List<int> categorisId);
        void EditBlog(Blog blog);
        Blog DeleteBlog(int id);
        public List<Category> GetCategories();
    }
}

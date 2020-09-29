using ksp.blog.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ksp.blog.framework
{
    public class BlogUnitOfWork : UnitOfWork, IBlogUnitOfWork
    {
        public BlogUnitOfWork(
            FrameworkContext dbContext,
            ICategoryRepository categoryRepository)
                : base(dbContext)
        {
            CategoryRepository = categoryRepository;
        }

        public ICategoryRepository CategoryRepository { get ; set; }
    }
}

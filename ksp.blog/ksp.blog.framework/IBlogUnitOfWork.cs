using ksp.blog.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ksp.blog.framework
{
    public interface IBlogUnitOfWork : IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; set; }
    }
}

using ksp.blog.data;
using ksp.blog.framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ksp.blog.framework
{
    public interface ICategoryRepository  : IRepository<Category, int, FrameworkContext>
    {

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ksp.blog.framework.Domain
{
    public class BlogCategory
    {
        public Blog Blog { get; set; }
        public Category Category { get; set; }

        public int BlogId { get; set; }
        public int CategoryId { get; set; }
    }
}

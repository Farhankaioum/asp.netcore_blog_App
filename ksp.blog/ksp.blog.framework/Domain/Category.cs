using ksp.blog.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ksp.blog.framework.Domain
{
    public class Category : IEntity<int>
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public List<BlogCategory> BlogCategories { get; set; }
    }
}

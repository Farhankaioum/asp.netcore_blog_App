using ksp.blog.data;
using ksp.blog.membership.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ksp.blog.framework.Domain
{
    public class Blog : IEntity<int>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public string AuthorId { get; set; }

        public List<BlogCategory> BlogCategories { get; set; }

    }
}

using ksp.blog.framework;
using ksp.blog.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ksp.blog.web.Areas.Admin.Models.BlogViewModel
{
    public class BlogIndexViewModel : BlogBaseModel
    {
        public BlogIndexViewModel(IBlogService blogService)
            : base(blogService) { }

        public BlogIndexViewModel()
            : base() {  }

        internal object GetBlogs(DataTablesAjaxRequestModel tableModel)
        {
            var data = _blogService.GetBlogs(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Title", "Description", "Id" })
                );

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                    select new string[]
                    {
                        record.Title,
                        record.Description.Substring(0, 20) + "....",
                        record.Id.ToString()

                    }).ToArray()
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ksp.blog.web.Areas.Admin.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public string IConCssClass { get; set; }
        public string StyleCssClass { get; set; }

        public ResponseModel()
        {

        }

        public ResponseModel(string message, ResponseType type)
        {
            if (type == ResponseType.Success)
            {
                IConCssClass = "fa-check";
                StyleCssClass = "alert-success";
                Title = "Success!";
            }

            else if (type == ResponseType.Failure)
            {
                IConCssClass = "fa-ban";
                StyleCssClass = "alert-danger";
                Title = "Error!";
            }

            Message = message;
        }
    }
}

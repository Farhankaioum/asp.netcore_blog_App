using Autofac;
using ksp.blog.framework.ExtensionMethod;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ksp.blog.web.Areas.Admin.Models
{
    public class AdminBaseModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MenuModel MenuModel { get; set; }

        public ResponseModel Response {
            get
            {
                if (_httpContextAccessor.HttpContext.Session.IsAvailable 
                    && _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(Response)))
                {
                    var response = _httpContextAccessor.HttpContext.Session.Get<ResponseModel>(nameof(Response));

                    _httpContextAccessor.HttpContext.Session.Remove(nameof(Response));

                    return response;
                }

                else
                {
                    return null;
                }
            }

            set
            {
                _httpContextAccessor.HttpContext.Session.Set(nameof(Response), value);
            }
         }

        public AdminBaseModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public AdminBaseModel()
        {
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }
    }
}


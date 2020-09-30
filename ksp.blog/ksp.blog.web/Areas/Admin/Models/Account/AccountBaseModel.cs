using Autofac;
using ksp.blog.membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ksp.blog.web.Areas.Admin.Models.Account
{
    public class AccountBaseModel : AdminBaseModel, IDisposable
    {
        protected readonly IMembershipService _membershipService;

        public AccountBaseModel(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public AccountBaseModel()
        {
            _membershipService = Startup.AutofacContainer.Resolve<IMembershipService>();
        }

        public void Dispose()
        {
            _membershipService?.Dispose();
        }
    }
}

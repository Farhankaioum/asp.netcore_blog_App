using ksp.blog.membership.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ksp.blog.membership
{
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipUnitOfWork _membershipUnitOfWork;

        public MembershipService(IMembershipUnitOfWork membershipUnitOfWork)
        {
            _membershipUnitOfWork = membershipUnitOfWork;
        }

        public int Login(string userName, string password, bool rememberMe)
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }

        public int Registration(ApplicationUser applicationUser)
        {
            throw new NotImplementedException();
        }
    }
}

using ksp.blog.membership.Entities;
using ksp.blog.membership.Services;
using System;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace ksp.blog.membership
{
    public class MembershipService : IMembershipService, IDisposable
    {
        private readonly IMembershipUnitOfWork _membershipUnitOfWork;
        private readonly UserManager _userManager;
        private readonly SignInManager signInManager;

        public MembershipService(IMembershipUnitOfWork membershipUnitOfWork, UserManager userManager, SignInManager signInManager)
        {
            _membershipUnitOfWork = membershipUnitOfWork;
            _userManager = userManager;
            this.signInManager = signInManager;
        }

        public MembershipService()
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }

        public void Registration(RegistrationModel model)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };

         _userManager.CreateAsync(applicationUser, model.Password);

        }
    }
}

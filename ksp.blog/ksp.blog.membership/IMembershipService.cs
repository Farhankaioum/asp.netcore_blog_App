using ksp.blog.membership.Entities;
using System;

namespace ksp.blog.membership
{
    public interface IMembershipService : IDisposable
    {
        void Registration(RegistrationModel model);
        void Login(string userName, string password);
        void LogOut();
        
    }
}

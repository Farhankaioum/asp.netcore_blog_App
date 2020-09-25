using ksp.blog.membership.Entities;

namespace ksp.blog.membership
{
    public interface IMembershipService
    {
        int Registration(ApplicationUser applicationUser);
        int Login(string userName, string password, bool rememberMe);
        void LogOut();
        
    }
}

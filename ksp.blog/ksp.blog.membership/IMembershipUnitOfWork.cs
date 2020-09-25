using System;

namespace ksp.blog.membership
{
    public interface IMembershipUnitOfWork : IDisposable
    {
        void Save();
        IMembershipRepository MembershipRepository { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;

namespace ksp.blog.membership.Entities
{
    public class RoleClaim : IdentityRoleClaim<Guid>
    {
        public RoleClaim()
            :base()
        {

        }
    }
}

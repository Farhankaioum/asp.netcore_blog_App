using Microsoft.AspNetCore.Identity;
using System;

namespace ksp.blog.membership.Entities
{
    public class UserToken : IdentityUserToken<Guid>
    {
        public UserToken()
            :base()
        {

        }
    }
}

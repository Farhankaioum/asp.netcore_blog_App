﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ksp.blog.membership.Entities
{
    public class UserClaim : IdentityUserClaim<Guid>
    {
        public UserClaim()
            :base()
        {

        }
    }
}

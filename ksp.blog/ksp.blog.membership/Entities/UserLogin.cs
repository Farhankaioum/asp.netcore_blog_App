﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ksp.blog.membership.Entities
{
    public class UserLogin : IdentityUserLogin<Guid>
    {
        public UserLogin()
            :base()
        {

        }
    }
}

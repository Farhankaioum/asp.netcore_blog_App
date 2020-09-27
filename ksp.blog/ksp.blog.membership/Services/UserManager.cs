using ksp.blog.membership.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ksp.blog.membership.Services
{
    public class UserManager : UserManager<ApplicationUser>
    {
        public UserManager(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, IServiceProvider service,
            ILogger<UserManager<ApplicationUser>> logger)
             :base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, service, logger)
        {

        }

        public async Task<string> GetCustomNameAsync(ClaimsPrincipal principal)
        {
            var user = await GetUserAsync(principal);
            return user.UserName;
        }
    }
}

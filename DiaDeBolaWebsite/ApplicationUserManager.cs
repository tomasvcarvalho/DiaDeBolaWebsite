using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaDeBolaWebsite
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators, IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        public async Task<string> GetFirstNameAsync(ApplicationUser user) 
        {
            //TODO
            return user.FirstName; 
        } 

        public async Task<string> GetLastNameAsync(ApplicationUser user)
        {
            //TODO
            return user.LastName; 
        } 

        public async Task<IdentityResult> SetFirstNameAsync(ApplicationUser user, string newFirstName) 
        {
            //TODO
            return new IdentityResult(); 
        } 

        public async Task<IdentityResult> SetLastNameAsync(ApplicationUser user, string newLastName) 
        {
            //TODO
            return new IdentityResult(); 
        }
    }
}

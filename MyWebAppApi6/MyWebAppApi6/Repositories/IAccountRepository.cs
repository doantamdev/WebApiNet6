using Microsoft.AspNetCore.Identity;
using MyWebAppApi6.Models;

namespace MyWebAppApi6.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}

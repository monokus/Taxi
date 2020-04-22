using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Taxi.Web.Data.Entities;
using Taxi.Web.Models;

namespace Taxi.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public UserHelper(
                UserManager<UserEntity> userManager,
                     RoleManager<IdentityRole> roleManager,
                        SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> AddUserAsync(UserEntity user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(UserEntity user, string rolename)
        {
            await _userManager.AddToRoleAsync(user, rolename);
        }

        public async Task CheckRoleAsync(string rolename)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(rolename);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = rolename
                });
            }
        }

        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> IsUserInRoleAsync(UserEntity user, string rolename)
        {
            return await _userManager.IsInRoleAsync(user, rolename);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {            

            return await _signInManager.PasswordSignInAsync(
                                                        model.Username,
                                                            model.Password,
                                                                model.RememberMe,
                                                                    false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

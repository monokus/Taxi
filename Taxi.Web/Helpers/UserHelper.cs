using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Taxi.Web.Data.Entities;

namespace Taxi.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserHelper(
                UserManager<UserEntity> userManager,
                     RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendsAppApi.Models;
using Microsoft.AspNetCore.Identity;

namespace FriendsAppApi.Repository
{
    public class Auth : IAuth
    {
        private readonly SignInManager<ApiUser> _signInManager;
        private readonly UserManager<ApiUser> _userManager;

        public Auth(SignInManager<ApiUser> signInManager,
            UserManager<ApiUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<ApiUser> GetUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user;
        }

        public async Task<SignInResult> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ApiUser> Register(ApiUser user, string password)
        {
            await _userManager.CreateAsync(user, password);

            return await  _userManager.FindByNameAsync(user.UserName);
        }
    }
}

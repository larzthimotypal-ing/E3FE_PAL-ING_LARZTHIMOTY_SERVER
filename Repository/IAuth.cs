using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendsAppApi.Models;
using Microsoft.AspNetCore.Identity;

namespace FriendsAppApi.Repository
{
    public interface IAuth
    {
        Task<ApiUser> GetUser(string username);
        Task<SignInResult> Login(string username, string password);
        Task<ApiUser> Register(ApiUser user, string password);
        Task Logout();
    }
}

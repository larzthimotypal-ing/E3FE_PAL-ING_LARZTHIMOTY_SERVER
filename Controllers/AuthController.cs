using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendsAppApi.Dtos;
using FriendsAppApi.Models;
using FriendsAppApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FriendsAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _auth;
        public AuthController(IAuth auth)
        {
            _auth = auth;
        }

        [HttpGet]
        public ActionResult<ApiUser> FindUser(string username)
        {
            return _auth.GetUser(username).Result;
        }



        [HttpPost]
        [Route("register")]
        public ActionResult Register([FromBody] RegisterDto dto)
        {
            var user = new ApiUser
            {
                UserName = dto.Username,
                Email = dto.Email,
                Name = dto.Name
            };

             var entity = _auth.Register(user, dto.Password).Result;

            

            return CreatedAtAction(nameof(FindUser),new { userName = entity.UserName },entity);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {

            var result = _auth.Login(dto.Username, dto.Password).Result;
            var message = "failed";

            if (result.Succeeded)
            {
                message = "success";
            }


            return Ok(new { 
                message = message
            });
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            _auth.Logout();
            return Ok(new
            {
                message = "success"
            });
        }
    }

    
}

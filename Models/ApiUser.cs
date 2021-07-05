using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FriendsAppApi.Models
{
    public class ApiUser : IdentityUser
    {
        public string Name { get; set; }
    }
}

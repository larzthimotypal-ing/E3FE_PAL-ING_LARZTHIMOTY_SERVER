using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendsAppApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FriendsAppApi.Data
{
    public class IdentityContext : IdentityDbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }
        
        public DbSet<ApiUser> ApiUsers { get; set; }
        
    }
}

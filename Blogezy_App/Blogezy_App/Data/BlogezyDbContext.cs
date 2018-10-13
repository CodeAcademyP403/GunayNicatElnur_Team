using Blogezy_App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogezy_App.Data
{
    public class BlogezyDbContext : IdentityDbContext
    {
        public BlogezyDbContext(DbContextOptions<BlogezyDbContext> identityDb):base(identityDb)
        {

        }

        public DbSet<UserApp> UserApps { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Site.Data
{
    public class Context :IdentityDbContext
    {
        private readonly DbContextOptions _options;

        public Context(DbContextOptions<Context> options) : base(options)
        {
            //_options = options;
        }

        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
    }
}

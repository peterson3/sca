using Microsoft.EntityFrameworkCore;
using SCA.Auth.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCA.Auth.API.Repository
{

    public class AuthContext : DbContext
    {

        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



        }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}

using galaxypremiere.Application.Configurations;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.Constants;
using galaxypremiere.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Persistence.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions option) : base(option)
        {
        }

        // Tables
        public DbSet<Users> Users { get; set; } // Users Table
        public DbSet<Roles> Roles { get; set; } // Roles Table
        public DbSet<UsersInRoles> UsersInRoles { get; set; } // UsersInRoles Table
        // End

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //> FLuent API of Entity Configurations
            //---- Users
            modelBuilder.ApplyConfiguration(new UsersConfigurations());
            //---- ROles
            modelBuilder.ApplyConfiguration(new RolesConfigurations());
            //< End
        }
    }
}

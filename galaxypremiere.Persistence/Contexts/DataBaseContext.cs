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
            // Data-Seeding
            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 1, Name = nameof(RoleConstants.King) });
            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 2, Name = nameof(RoleConstants.SuperAdmin) });
            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 3, Name = nameof(RoleConstants.Admin) });
            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 4, Name = nameof(RoleConstants.Client) });
            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 5, Name = nameof(RoleConstants.User) });
            // End

            // To avoid Duplicated Records
            modelBuilder.Entity<Users>().HasIndex(x=>x.Email).IsUnique();
            // End
        }
    }
}

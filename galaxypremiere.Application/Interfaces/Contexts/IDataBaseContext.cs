using galaxypremiere.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.Contexts
{
    public interface IDataBaseContext 
    {
        DbSet<Users> Users { get; set; } // Users Table
        DbSet<Roles> Roles { get; set; } // Roles Table
        DbSet<UsersInRoles> UsersInRoles { get; set; } // UsersInRoles Table
        DbSet<UsersActionsLog> UsersActionsLog { get; set; } // UsersActionsLog Table
        DbSet<UsersLoginLog> UsersLoginLog { get; set; } // UsersLoginLog

        //SaveChanges
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}

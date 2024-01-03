using galaxypremiere.Domain.Common;
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
        DbSet<UsersInformation> UsersInformation { get; set; } // UsersInformation Table
        DbSet<Countries> Countries { get; set; } // Countries Table
        DbSet<Languages> Languages { get; set; } // Languages Table
        DbSet<UsersAddress> UsersAddress { get; set; } // Users' Address Address
        DbSet<UsersPositions> UsersPositions { get; set; } // Users' Position Table
        DbSet<UsersEducation> UsersEducation { get; set; } // User's Educations
        DbSet<UsersFavoriteMovies> UsersFavoriteMovies { get; set; } // User's Favorite Movies

        //SaveChanges
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}

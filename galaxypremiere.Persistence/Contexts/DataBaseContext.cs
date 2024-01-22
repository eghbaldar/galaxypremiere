using AutoMapper;
using AutoMapper.Internal;
using galaxypremiere.Application.Configurations;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UserActionsLog.Commands.PostUserActionLog;
using galaxypremiere.Application.Services.UserActionsLog.FacadePattern;
using galaxypremiere.Common.Constants;
using galaxypremiere.Domain.Common;
using galaxypremiere.Domain.Entities.Users;
using galaxypremiere.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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
        public DbSet<UsersActionsLog> UsersActionsLog { get; set; } // UsersActionsLog Table
        public DbSet<UsersLoginLog> UsersLoginLog { get; set; } // UsersLoginLog Table
        public DbSet<UsersInformation> UsersInformation { get; set; } // UsersInformation Table
        public DbSet<Countries> Countries { get; set; } // Countries Table
        public DbSet<Languages> Languages { get; set; } // Languages Table
        public DbSet<UsersAddress> UsersAddress { get; set; } // Users' Address Table
        public DbSet<UsersPositions> UsersPositions { get; set; } // Users' Position Table
        public DbSet<UsersEducation> UsersEducation { get; set; } // User's Educations
        public DbSet<UsersFavoriteMovies> UsersFavoriteMovies { get; set; } // User's Educations
        public DbSet<UsersCompanies> UsersCompanies { get; set; } // User's Companies
        public DbSet<UsersNews> UsersNews { get; set; } // Users' News
        public DbSet<UsersLinks> UsersLinks { get; set; } // Users' Links
        public DbSet<UsersAttachments> UsersAttachments { get; set; } // Users' Attachments
        public DbSet<UsersAlbums> UsersAlbums { get; set; } // Users' Albums
        public DbSet<UsersPhotos> UsersPhotos { get; set; } // Users' Photos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //> FLuent API of Entity Configurations
            //---- Users
            modelBuilder.ApplyConfiguration(new UsersConfigurations());
            //---- Roles
            modelBuilder.ApplyConfiguration(new RolesConfigurations());
            //---- Countries
            modelBuilder.ApplyConfiguration(new CountriesConfigurations()); 
            //---- Languages
            modelBuilder.ApplyConfiguration(new LanguagesConfigurations());
            //---- Profile Educations
            modelBuilder.ApplyConfiguration(new UsersProfileEducationConfigurations());
            //---- Profile Favorite Movies
            modelBuilder.ApplyConfiguration(new UsersProfileFavoriteMoviesConfigurations());
            //---- Profile Companies
            modelBuilder.ApplyConfiguration(new UsersProfileCompaniesConfigurations());            
            //---- Profile Companies
            modelBuilder.ApplyConfiguration(new UsersProfileNewsConfigurations());
            //---- Profile Links
            modelBuilder.ApplyConfiguration(new UsersProfileLinksConfigurations());     
            //---- Profile Attachment
            modelBuilder.ApplyConfiguration(new UsersProfileAttachmentConfigurations());
            //---- Photo Albums
            modelBuilder.ApplyConfiguration(new UsersPhotoAlbumConfigurations());    
            //---- Photo Photo
            modelBuilder.ApplyConfiguration(new UsersPhotoPhotoConfigurations());
            //< End
        }
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
           .Where(e =>
               e.State == EntityState.Modified ||
               e.State == EntityState.Added ||
               e.State == EntityState.Deleted
               ).ToList();
            foreach (var entry in modifiedEntries)
            {
                var entityType = entry.Context.Model.FindEntityType(entry.Entity.GetType());
                var inserted = entityType.FindProperty("InsertDate");
                var updated = entityType.FindProperty("UpdateDate");
                var deleted = entityType.FindProperty("DeleteDate");               
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (inserted != null) entry.Property("InsertDate").CurrentValue = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        if (updated != null) entry.Property("UpdateDate").CurrentValue = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        if (deleted != null)
                        {
                            entry.Property("DeleteDate").CurrentValue = DateTime.Now;
                            entry.State = EntityState.Modified;
                        }
                        break;
                }
            }
            return base.SaveChanges();
        }
        //private void RecordModifiedProperties(EntityEntry entry)
        //{

        //    foreach (var property in entry.Entity.GetType().GetTypeInfo().DeclaredProperties)
        //    {
        //        bool CheckCollection = property.PropertyType.IsCollection();
        //        if (!CheckCollection)
        //        {
        //            try
        //            {
        //                var originalValue = entry.Property(property.Name).OriginalValue;
        //                var currentValue = entry.Property(property.Name).CurrentValue;

        //                //https://stackoverflow.com/questions/37548766/dbcontext-override-savechanges-not-firing
        //                //https://stackoverflow.com/questions/32597498/show-original-values-entity-framework-7
        //                //https://stackoverflow.com/questions/12699892/many-to-many-relationship-detecting-changes
        //                //https://stackoverflow.com/questions/21025778/entity-framework-6-getobjectstateentries-expected-modified-entities-have-state

        //                if (originalValue.ToString() != currentValue.ToString()) //only will be changed when a thing changes!
        //                {
        //                    UsersActionsLog postUserActionLogService = new UsersActionsLog()
        //                    {
        //                        Entity = entry.Entity.GetType().Name, //entityName 
        //                        Action = entry.State.ToString(),
        //                        NewValue = currentValue.ToString(),
        //                        OldValue = originalValue.ToString(),
        //                        PrimaryKeyValue = "0",
        //                        PropertyName = property.Name,
        //                        Successful = true,
        //                        //UserId = 1,
        //                    };
        //                    UsersActionsLog.Add(postUserActionLogService);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                UsersActionsLog postUserActionLogService = new UsersActionsLog()
        //                {
        //                    Entity = entry.Entity.GetType().Name, //entityName 
        //                    Action = entry.State.ToString(),
        //                    NewValue = "",
        //                    OldValue = "",
        //                    PrimaryKeyValue = "0",
        //                    PropertyName = property.Name,
        //                    Successful = false,
        //                    //UserId = 0,
        //                };
        //                UsersActionsLog.Add(postUserActionLogService);
        //            }
        //        }
        //    }
        //}
    }
}

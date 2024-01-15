using galaxypremiere.Common.Constants;
using galaxypremiere.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Configurations
{
    public class RolesConfigurations : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            // Data-Seeding
            builder.HasData(new Roles { Id = 1, Name = nameof(RoleConstants.King) });
            builder.HasData(new Roles { Id = 2, Name = nameof(RoleConstants.SuperAdmin) });
            builder.HasData(new Roles { Id = 3, Name = nameof(RoleConstants.Admin) });
            builder.HasData(new Roles { Id = 4, Name = nameof(RoleConstants.Client) });
            builder.HasData(new Roles { Id = 5, Name = nameof(RoleConstants.User) });
            // End
        }
    }
}

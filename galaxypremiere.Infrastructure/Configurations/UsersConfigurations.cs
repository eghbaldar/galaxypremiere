using galaxypremiere.Common.Constants;
using galaxypremiere.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Configurations
{
    public class UsersConfigurations :IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            // Filter Deleted Records [show only records who are not deleted]
            builder.HasQueryFilter(u => u.DeleteDate == null);
            // End
        }
    }
}

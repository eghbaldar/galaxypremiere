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
    public class UsersProfileConfigurations : IEntityTypeConfiguration<UsersEducation>
    {
        public void Configure(EntityTypeBuilder<UsersEducation> builder)
        {
            // Filter Deleted Records [show only records who are not deleted]
            builder.HasQueryFilter(u => u.DeleteDate == null);
            // End
        }
    }
}
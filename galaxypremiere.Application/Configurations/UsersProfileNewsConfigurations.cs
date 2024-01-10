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
    public class UsersProfileNewsConfigurations: IEntityTypeConfiguration<UsersNews>
    {
        public void Configure(EntityTypeBuilder<UsersNews> builder)
        {
            // Filter Deleted Records [show only records who are not deleted]
            builder.HasQueryFilter(x => x.DeleteDate == null);
            //
        }
    }
}

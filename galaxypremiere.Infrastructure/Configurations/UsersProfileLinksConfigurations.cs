using galaxypremiere.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Configurations
{
    public class UsersProfileLinksConfigurations : IEntityTypeConfiguration<UsersLinks>
    {
        public void Configure(EntityTypeBuilder<UsersLinks> builder)
        {
            builder.HasQueryFilter(x => x.DeleteDate == null);
        }
    }
}

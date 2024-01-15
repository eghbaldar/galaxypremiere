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
    public class UsersProfileAttachmentConfigurations : IEntityTypeConfiguration<UsersAttachments>
    {
        public void Configure(EntityTypeBuilder<UsersAttachments> builder)
        {
            builder.HasQueryFilter(x => x.DeleteDate == null);
        }
    }
}

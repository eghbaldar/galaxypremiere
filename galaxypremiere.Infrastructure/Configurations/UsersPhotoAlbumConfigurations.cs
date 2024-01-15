﻿using galaxypremiere.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Infrastructure.Configurations
{
    public class UsersPhotoAlbumConfigurations : IEntityTypeConfiguration<UsersAlbums>
    {
        public void Configure(EntityTypeBuilder<UsersAlbums> builder)
        {
            builder.HasQueryFilter(x => x.DeleteDate == null);
        }
    }
}

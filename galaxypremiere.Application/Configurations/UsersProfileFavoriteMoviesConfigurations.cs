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
    public class UsersProfileFavoriteMoviesConfigurations : IEntityTypeConfiguration<UsersFavoriteMovies>
    {
        public void Configure(EntityTypeBuilder<UsersFavoriteMovies> builder)
        {
            // Filter Deleted Records [show only records who are not deleted]
            builder.HasQueryFilter(u => u.DeleteDate == null);
            //
        }
    }
}

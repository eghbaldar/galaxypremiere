using galaxypremiere.Common.Constants;
using galaxypremiere.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.ConfigurationsConfigurationsConfigurations
{
    public class UserPositionConfigurations : IEntityTypeConfiguration<UsersPositions>
    {
        public void Configure(EntityTypeBuilder<UsersPositions> builder)
        {
            builder.HasData(new UsersPositions { Id = 1, Position = nameof(UserPositions.Director), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 2, Position = nameof(UserPositions.Producer), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 3, Position = nameof(UserPositions.Director_of_Photography), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 4, Position = nameof(UserPositions.Cameraman), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 5, Position = nameof(UserPositions.Sound), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 6, Position = nameof(UserPositions.Editor), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 7, Position = nameof(UserPositions.Colorist), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 8, Position = nameof(UserPositions.VFX), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 9, Position = nameof(UserPositions.Composer), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 10, Position = nameof(UserPositions.Animator), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 11, Position = nameof(UserPositions.Actor), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 12, Position = nameof(UserPositions.Distributor), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 13, Position = nameof(UserPositions.Executive_Manager), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 14, Position = nameof(UserPositions.Sound_Mixer), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 15, Position = nameof(UserPositions.Camera_Assistant), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 16, Position = nameof(UserPositions.Boom_Operator), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 17, Position = nameof(UserPositions.Director_Assistant), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 18, Position = nameof(UserPositions.Makeup_Artist), Suggestion = 0 });
            builder.HasData(new UsersPositions { Id = 19, Position = nameof(UserPositions.Costume_Designer), Suggestion = 0 });
        }
    }
}

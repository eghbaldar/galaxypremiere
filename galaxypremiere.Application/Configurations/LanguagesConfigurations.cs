using galaxypremiere.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Configurations
{
    public class LanguagesConfigurations : IEntityTypeConfiguration<Languages>
    {
        public void Configure(EntityTypeBuilder<Languages> builder)
        {
            // Data-Seeding
            CultureInfo[] langs =
                CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Where(x => x.DisplayName.Contains("(") == false)
                .ToArray();

            builder.HasData(new Languages
            {
                Id = 1,
                NameEnglish = "Not Specified",
                NameNative = "Not Specified",
            });
            for (int i = 0; i < langs.Length - 1; i++)
            {
                builder.HasData(new Languages
                {
                    Id = i + 2,
                    LanguageCountryCode = langs[i].Name,
                    NameEnglish = langs[i].DisplayName,
                    NameNative = langs[i].NativeName,
                });
            }
            // End
        }
    }
}

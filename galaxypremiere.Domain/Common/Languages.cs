using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Common
{
    public class Languages
    {
        public int Id { get; set; }
        public string NameEnglish { get; set; }
        public string? NameNative { get; set; }
        public string? LanguageCountryCode { get; set; }
    }
}

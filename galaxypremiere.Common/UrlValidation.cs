using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace galaxypremiere.Common
{
    public class UrlValidation
    {
        private readonly string _url;
        private readonly string _dmoain;
        public UrlValidation(string url, string dmoain)
        {
            _url = url;
            _dmoain = dmoain;
        }
        public bool CheckUrlStructure()
        {
            string pattern = @"^(https?|ftp)://[^\s/$.?#].[^\s]*$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(_url);
        }
        public bool MatchUrlWithDomain()
        {
            return _url.Substring(0, _dmoain.Length).Equals(_dmoain);
        }
    }
}

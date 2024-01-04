using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Metags.Queries.GetMetagsInfoByLink
{
    public interface IGetMetagsInfoByLinkService
    {
        ResultDto Execute(string link,string domain);
    }
}

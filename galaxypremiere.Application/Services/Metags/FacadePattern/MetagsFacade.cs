using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.Metags.Queries.GetMetagsInfoByLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Metags.FacadePattern
{
    public class MetagsFacade: IMetagsFacade
    {
        // Get Metags Info By Link
        private GetMetagsInfoByLinkService _getMetagsInfoByLinkService;
        public GetMetagsInfoByLinkService GetMetagsInfoByLinkService
        { 
            get { return _getMetagsInfoByLinkService= _getMetagsInfoByLinkService?? new GetMetagsInfoByLinkService(); } 
        }
    }
}

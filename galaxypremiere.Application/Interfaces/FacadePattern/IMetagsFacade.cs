using galaxypremiere.Application.Services.Metags.Queries.GetMetagsInfoByLink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.FacadePattern
{
    public interface IMetagsFacade
    {
        public GetMetagsInfoByLinkService GetMetagsInfoByLinkService { get; }
    }
}

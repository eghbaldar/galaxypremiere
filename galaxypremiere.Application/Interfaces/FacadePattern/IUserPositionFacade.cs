using galaxypremiere.Application.Services.UserPosition.Queries.GetUsersPositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.FacadePattern
{
    public interface IUserPositionFacade
    {
        public GetUsersPositionsService GetUsersPositionsService { get; }
    }
}

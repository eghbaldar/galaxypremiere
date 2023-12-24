using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UserPosition.Commands.PostUsersPositionSuggestion
{
    public interface IPostUsersPositionSuggestionService
    {
        ResultDto Execute(RequestPostUsersPositionSuggestionServiceDto req);
    }
}
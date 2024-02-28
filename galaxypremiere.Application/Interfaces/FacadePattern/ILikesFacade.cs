using galaxypremiere.Application.Services.Likes.Commands.PostLike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.FacadePattern
{
    public interface ILikesFacade
    {
        PostLikeService PostLikeService { get; }
    }
}

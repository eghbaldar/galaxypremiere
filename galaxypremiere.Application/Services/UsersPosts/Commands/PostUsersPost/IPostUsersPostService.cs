using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPosts.Commands.PostUsersPost
{
    public class RequestPostUsersPostServiceDto
    {
        public long UsersId { get; set; }
        public string Post { get; set; }
    }
    public interface IPostUsersPostService
    {
        ResultDto Execute(RequestPostUsersPostServiceDto req);
    }
    public class PostUsersPostService : IPostUsersPostService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public PostUsersPostService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto Execute(RequestPostUsersPostServiceDto req)
        {
            if (req == null) return new ResultDto { IsSuccess = false };
            galaxypremiere.Domain.Entities.Users.UsersPosts usersPosts = new galaxypremiere.Domain.Entities.Users.UsersPosts();
            usersPosts = _mapper.Map<galaxypremiere.Domain.Entities.Users.UsersPosts>(req);
            _context.UsersPosts.Add(usersPosts);
            _context.SaveChanges();
            return new ResultDto { IsSuccess = true };
        }
    }
}

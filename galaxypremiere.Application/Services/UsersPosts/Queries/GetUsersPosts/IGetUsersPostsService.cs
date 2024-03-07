using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPosts.Queries.GetUsersPosts
{
    public class GetUsersPostsServiceDto
    {        
        public Guid PostId { get; set; }
        public string Post { get; set; }
        public long UsersId { get; set; } // page owner's Id
        public string OwnerFullname { get; set; } // based on "UsersId"
        public long From { get; set; } // who is posted
        public string FromFullname { get; set; } // based on "From"        
        public DateTime InsertDate{ get; set; }
    }
    public class ResultGetUsersPostsServiceDto
    {
        public List<GetUsersPostsServiceDto> resultGetUsersPostsServiceDto { get; set; }
    }
    public class RequestGetUsersPostsServiceDto
    {
        public string Username { get; set; }
    }
    public interface IGetUsersPostsService
    {
        ResultDto<ResultGetUsersPostsServiceDto> Execute(RequestGetUsersPostsServiceDto req);
    }
    public class GetUsersPostsService : IGetUsersPostsService
    {
        private readonly IDataBaseContext _context;
        public GetUsersPostsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultGetUsersPostsServiceDto> Execute(RequestGetUsersPostsServiceDto req)
        {
            if (req == null) return new ResultDto<ResultGetUsersPostsServiceDto> { Data = null, IsSuccess = false };
            var result =
                (from p in _context.UsersPosts
                 join info in _context.UsersInformation on p.UsersId equals info.UsersId
                 where info.Username==req.Username && p.UsersId == info.UsersId && p.Archive == false
                 orderby p.InsertDate descending
                 select new GetUsersPostsServiceDto
                 {
                     UsersId= info.UsersId,
                     From=p.From,
                     OwnerFullname = (info.Firstname ?? null) + (info.MiddleName ?? null) + (info.Surname ?? null),
                     FromFullname = "",
                     Post=p.Post,
                     PostId = p.Id,
                     InsertDate = p.InsertDate,
                 }).ToList();
            return new ResultDto<ResultGetUsersPostsServiceDto>
            {
                Data = new ResultGetUsersPostsServiceDto
                {
                     resultGetUsersPostsServiceDto= result,
                }
            };
            // check the archive ...
        }
    }
}

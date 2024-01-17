using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileAttachments
{
    public class GetUserProfileAttachmentsService : IGetUserProfileAttachmentsService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetUserProfileAttachmentsService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto<ResultGetUserProfileAttachmentsServiceDto> Execute(RequestGetUserProfileAttachmentsServiceDto req)
        {
            if (req == null)
            {
                return new ResultDto<ResultGetUserProfileAttachmentsServiceDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Something went wrong."
                };
            }
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var attahcment = _context.UsersAttachments
                    .Where(u => u.UsersId == req.UsersId)
                    .ToList();
                if (attahcment != null)
                {
                    var result = attahcment.Select(
                        at => _mapper.Map<GetUserProfileAttachmentsServiceDto>(at)
                        ).OrderByDescending(e => e.InsertDate).ToList();
                    return new ResultDto<ResultGetUserProfileAttachmentsServiceDto>()
                    {
                        Data = new ResultGetUserProfileAttachmentsServiceDto
                        {
                            getUserProfileAttachmentsServiceDto = result,
                        },
                        IsSuccess = true,
                        Message = "The user does not exist."
                    };
                }
            }
            else// _mapper.Map<UsersEducation>(education)
            {
                return new ResultDto<ResultGetUserProfileAttachmentsServiceDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "The user does not exist."
                };
            }
            return new ResultDto<ResultGetUserProfileAttachmentsServiceDto>()
            {
                Data = null,
                IsSuccess = false,
                Message = "The user does not exist."
            };
        }
    }
}

using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;

namespace galaxypremiere.Application.Services.UserPosition.Commands.PostUsersPositionSuggestion
{
    public class PostUsersPositionSuggestionService : IPostUsersPositionSuggestionService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public PostUsersPositionSuggestionService(IDataBaseContext context, IMapper impper)
        {
            _context = context;
            _mapper = impper;
        }
        public ResultDto Execute(RequestPostUsersPositionSuggestionServiceDto req)
        {
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var resultCheckingSuggestedPosition = CheckSuggestedPosition(req.Position);
                if (resultCheckingSuggestedPosition.Status)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = resultCheckingSuggestedPosition.Message,
                    };
                }
                UsersPositions usersPositions = new UsersPositions();
                usersPositions = _mapper.Map<UsersPositions>(req);
                _context.UsersPositions.Add(usersPositions);
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "Your suggestion is sent. Thank you for your contribution."
                };
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The user does not exist."
                };
            }
        }
        public ResultCheckSuggestedPositionDto CheckSuggestedPosition(string position)
        {
            var positions = _context.UsersPositions.Where(up => up.Position == position).FirstOrDefault();
            if (positions == null)
            {
                // this suggested position does not alrealy exist.
                return new ResultCheckSuggestedPositionDto
                {
                    Status = false,
                    Message = null,
                };
            }
            else
            {
                // 0: The user's suggestion is verifed or already existed | 1: The user's suggestion is being under considered | 2: The user's suggestion is rejected.                
                switch (positions.Suggestion)
                {
                    case 0:
                        return new ResultCheckSuggestedPositionDto
                        {
                            Status = true,
                            Message = "The suggested position is already existed",
                        };
                    case 1:
                        return new ResultCheckSuggestedPositionDto
                        {
                            Status = true,
                            Message = "The suggested position is being under considered",
                        };
                    case 2:
                        return new ResultCheckSuggestedPositionDto
                        {
                            Status = true,
                            Message = "The suggested position was rejected",
                        };
                }
            }
            return new ResultCheckSuggestedPositionDto
            {
                Status = false,
                Message = null,
            };
        }
    }
}
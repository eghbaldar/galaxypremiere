using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileFavoriteMovies
{
    public class GetUserProfileFavoriteMoviesService : IGetUserProfileFavoriteMoviesService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetUserProfileFavoriteMoviesService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto<ResultGetUserProfileFavoriteMoviesServiceDto> Execute(RequestGetUserProfileFavoriteMoviesServiceDto req)
        {
            if (req == null)
            {
                return new ResultDto<ResultGetUserProfileFavoriteMoviesServiceDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Something went wrong."
                };
            }
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var favoriteMovie = _context.UsersFavoriteMovies
                    .Where(u => u.UsersId == req.UsersId)
                    .ToList();
                if (favoriteMovie != null)
                {
                    var ed = favoriteMovie.Select(e => new GetUserProfileFavoriteMoviesServiceDto
                    {
                        Id = e.Id,
                        ImdbLink = e.ImdbLink,
                        InsertDate = e.InsertDate,
                    }).OrderByDescending(e => e.InsertDate).ToList();
                    return new ResultDto<ResultGetUserProfileFavoriteMoviesServiceDto>()
                    {
                        Data = new ResultGetUserProfileFavoriteMoviesServiceDto
                        {
                            getUserProfileFavoriteMoviesServiceDto = ed,
                        },
                        IsSuccess = true,
                        Message = "The user does not exist."
                    };
                }
            }
            else// _mapper.Map<UsersEducation>(education)
            {
                return new ResultDto<ResultGetUserProfileFavoriteMoviesServiceDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "The user does not exist."
                };
            }
            return new ResultDto<ResultGetUserProfileFavoriteMoviesServiceDto>()
            {
                Data = null,
                IsSuccess = false,
                Message = "The user does not exist."
            };
        }
    }
}

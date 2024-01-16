using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileCompanies
{
    public class GetUserProfileCompaniesService : IGetUserProfileCompaniesService
    {
        private readonly IDataBaseContext _context;
        public GetUserProfileCompaniesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultGetUserProfileCompaniesServiceDto> Execute(RequestGetUserProfileCompaniesDto req)
        {
            if (req == null)
            {
                return new ResultDto<ResultGetUserProfileCompaniesServiceDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Something went wrong."
                };
            }
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var company = _context.UsersCompanies
                    .Where(u => u.UsersId == req.UsersId)
                    .ToList();
                if (company != null)
                {
                    var ed = company.Select(e => new GetUserProfileCompaniesDto
                    {
                        Id = e.Id,
                        CountryId = e.CountryId,
                        Name = e.Name,
                        Position=e.Position,                        
                        From = e.From,
                        To = e.To,
                        Address1 = e.Address1,
                        Address2= e.Address2,
                        City=e.City,
                        State=e.State,
                        PostalCode=e.PostalCode,
                        Phone=e.Phone,
                        RecoveryEmail=e.RecoveryEmail,
                        Website=e.Website,
                        Facebook=e.Facebook,
                        Instagram=e.Instagram,
                        Twitter=e.Twitter,
                        Stage32 =e.Stage32,
                        Youtube=e.Youtube,
                        Linkden=e.Linkden,
                        Vimeo=e.Vimeo,
                        Imdb=e.Imdb,
                        InsertDate = e.InsertDate,
                    }).OrderByDescending(e => e.InsertDate).ToList();
                    return new ResultDto<ResultGetUserProfileCompaniesServiceDto>()
                    {
                        Data = new ResultGetUserProfileCompaniesServiceDto
                        {
                            getUserProfileCompaniesDto = ed,
                        },
                        IsSuccess = true,
                        Message = "The user does not exist."
                    };
                }
            }
            else// _mapper.Map<UsersEducation>(education)
            {
                return new ResultDto<ResultGetUserProfileCompaniesServiceDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "The user does not exist."
                };
            }
            return new ResultDto<ResultGetUserProfileCompaniesServiceDto>()
            {
                Data = null,
                IsSuccess = false,
                Message = "The user does not exist."
            };
        }
    }
}

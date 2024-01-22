using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.UpdateUsersPhotosInformation
{
    public class UpdateUsersPhotoInformationService : IUpdateUsersPhotoInformationService
    {
        private readonly IDataBaseContext _context;
        public UpdateUsersPhotoInformationService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateUsersPhotoInformationServiceDto req)
        {
            if (req == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "Something went wrong"
                };
            }
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var photos = _context.UsersPhotos.Where(ue => ue.Id == req.Id).FirstOrDefault();
                if (photos != null)
                {
                    switch (req.ControlId)
                    {
                        case "txtPhotoTitle":
                            photos.Title = req.Value;
                            break;
                        case "txtPhotoDetail":
                            photos.Detail = req.Value;
                            break;
                    }
                    _context.SaveChanges();
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "The information have been updated"
                    };
                }
                else
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "The photo does not exist"
                    };
                }
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The user does not exist"
                };
            }
        }
    }
}

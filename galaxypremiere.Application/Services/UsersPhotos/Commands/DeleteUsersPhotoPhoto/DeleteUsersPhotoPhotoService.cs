using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using System.Transactions;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotoPhoto
{
    public class DeleteUsersPhotoPhotoService : IDeleteUsersPhotoPhotoService
    {
        private readonly IDataBaseContext _context;
        public DeleteUsersPhotoPhotoService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResulttDeleteUsersPhotoPhotoServiceDto> Execute(RequestDeleteUsersPhotoPhotoServiceDto req)
        {

            if (req == null)
            {
                return new ResultDto<ResulttDeleteUsersPhotoPhotoServiceDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Something went wrong"
                };
            }
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var photo = _context.UsersPhotos.Where(ue => ue.Id == req.Id).FirstOrDefault();
                if (photo != null)
                {
                    using (var transactionScope = new TransactionScope())
                    {
                        try
                        {
                            var albumId = photo.UsersAlbumsId;
                            var photos = _context.UsersPhotos
                                .Where(p => p.UsersAlbumsId.ToString() == albumId.ToString() && p.Id != photo.Id)
                                .OrderBy(_ => Guid.NewGuid())
                            .ToList(); // Materialize the query by calling ToList()

                            _context.UsersPhotos.Remove(photo); // attention: the deletion not be happened because of changeover of DataBaseContext.cs                    
                            _context.SaveChanges();
                            transactionScope.Complete(); // => commit

                            return new ResultDto<ResulttDeleteUsersPhotoPhotoServiceDto>
                            {
                                Data = new ResulttDeleteUsersPhotoPhotoServiceDto
                                {
                                    Leftover = (photos.Any()) ? true : false,
                                    RandomPhoto = photos.FirstOrDefault()?.Filename,
                                },
                                IsSuccess = true,
                                Message = "The information have been updated"
                            };
                        }
                        catch (ArgumentNullException ex)
                        {
                            transactionScope.Dispose(); //release => push
                            return new ResultDto<ResulttDeleteUsersPhotoPhotoServiceDto>
                            {
                                Data = null,
                                IsSuccess = false,
                                Message = "The photo does not exist"
                            };
                        }
                        catch (Exception)
                        {
                            transactionScope.Dispose();
                            throw;
                        }
                    }
                }
                else
                {
                    return new ResultDto<ResulttDeleteUsersPhotoPhotoServiceDto>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "The photo does not exist"
                    };
                }
            }
            else
            {
                return new ResultDto<ResulttDeleteUsersPhotoPhotoServiceDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "The user does not exist"
                };
            }
        }
    }
}

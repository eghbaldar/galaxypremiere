using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationPhotosByUsername
{
    public interface IGetUsersInformationPhotosByUsernameService
    {
        ResultGetUsersInformationPhotosByUsernameServiceDto Execute(RequestGetUsersInformationPhotosByUsernameServiceDto req);
    }
    public class GetUsersInformationPhotosByUsernameService : IGetUsersInformationPhotosByUsernameService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetUsersInformationPhotosByUsernameService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultGetUsersInformationPhotosByUsernameServiceDto Execute(RequestGetUsersInformationPhotosByUsernameServiceDto req)
        {
            if (req == null) return null;

            var groupedComments = _context.UsersPhotoComments.GroupBy(
                    p => p.UsersPhotosId, p => p.Comment, (key, g) => new { PhotoId = key, Count = g.Count() });

            var photos =
                (
                from p in _context.UsersPhotos
                join albums in _context.UsersAlbums on p.UsersAlbumsId equals albums.Id into GroupAlbums
                from albums in GroupAlbums.DefaultIfEmpty()
                join info in _context.UsersInformation on albums.UsersId equals info.UsersId into GroupUser
                from info in GroupUser.DefaultIfEmpty()
                where (info.Username == req.Username)
                select new
                {
                    Photos = p,
                }
                )
                .OrderBy(p => p.Photos.InsertDate)
                .Select(p => new GetUsersInformationPhotosByUsernameServiceDto
                {
                    Filename = p.Photos.Filename,
                    Id = p.Photos.Id,
                    Title = p.Photos.Title,
                    Detail = p.Photos.Detail,
                    VisitorCounter = p.Photos.VisitorCounter + 1,
                    CountComments = groupedComments.Where(gc => gc.PhotoId == p.Photos.Id).Select(gc => gc.Count).First().ToString(),
                })
                .Take(6)
                .ToList();

            if (photos != null)
            {
                return new ResultGetUsersInformationPhotosByUsernameServiceDto
                {
                    resultGetUsersInformationPhotosByUsernameServiceDto = photos,
                };
            }
            else
            {
                return null;
            }
        }
    }
}

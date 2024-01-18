using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotosAlbum;
using galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotosAlbum;
using galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotosPhoto;
using galaxypremiere.Application.Services.UsersPhotos.Commands.UpdateUsersPhotosAlbumRename;
using galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoAlbum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPhotos.FacadePattern
{
    public class UserPhotoFacade : IUserPhotoFacade
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _imapper;
        public UserPhotoFacade(IDataBaseContext context, IMapper imapper)
        {
            _context = context;
            _imapper = imapper;
        }
        // Post User Album
        private PostUsersPhotosAlbumService _postUsersPhotosAlbumService;
        public PostUsersPhotosAlbumService PostUsersPhotosAlbumService
        {
            get { return _postUsersPhotosAlbumService = _postUsersPhotosAlbumService ?? new PostUsersPhotosAlbumService(_context, _imapper); }
        }
        // Get User Album
        private GetUsersPhotoAlbumService _getUsersPhotoAlbumService;
        public GetUsersPhotoAlbumService GetUsersPhotoAlbumService
        {
            get { return _getUsersPhotoAlbumService = _getUsersPhotoAlbumService ?? new GetUsersPhotoAlbumService(_context, _imapper); }
        }
        // Delete User Album
        private DeleteUsersPhotosAlbumService _deleteUsersPhotosAlbumService;
        public DeleteUsersPhotosAlbumService DeleteUsersPhotosAlbumService
        {
            get { return _deleteUsersPhotosAlbumService = _deleteUsersPhotosAlbumService ?? new DeleteUsersPhotosAlbumService(_context); }
        }      
        // Update User Album Title Rename
        private UpdateUsersPhotosAlbumRenameService _updateUsersPhotosAlbumRenameService;
        public UpdateUsersPhotosAlbumRenameService UpdateUsersPhotosAlbumRenameService
        {
            get { return _updateUsersPhotosAlbumRenameService = _updateUsersPhotosAlbumRenameService ?? new UpdateUsersPhotosAlbumRenameService(_context); }
        }      
        // Post User Photo
        private PostUsersPhotosPhotoService _postUsersPhotosPhotoService;
        public PostUsersPhotosPhotoService PostUsersPhotosPhotoService
        {
            get { return _postUsersPhotosPhotoService = _postUsersPhotosPhotoService ?? new PostUsersPhotosPhotoService(_context,_imapper); }
        }
    }
}

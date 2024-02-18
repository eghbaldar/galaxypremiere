using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotoPhoto;
using galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotosAlbum;
using galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotoComment;
using galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotosAlbum;
using galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotosPhoto;
using galaxypremiere.Application.Services.UsersPhotos.Commands.UpdateUsersPhotosAlbumRename;
using galaxypremiere.Application.Services.UsersPhotos.Commands.UpdateUsersPhotosInformation;
using galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoAlbum;
using galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoPhotos;
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
        // Get User Photos
        private GetUsersPhotoPhotosService _getUsersPhotoPhotosService;
        public GetUsersPhotoPhotosService GetUsersPhotoPhotosService
        {
            get { return _getUsersPhotoPhotosService = _getUsersPhotoPhotosService ?? new GetUsersPhotoPhotosService(_context,_imapper); }
        }       
        // Update User Photos
        private UpdateUsersPhotoInformationService _updateUsersPhotoInformationService;
        public UpdateUsersPhotoInformationService UpdateUsersPhotoInformationService
        {
            get { return _updateUsersPhotoInformationService = _updateUsersPhotoInformationService ?? new UpdateUsersPhotoInformationService(_context); }
        }       
        // Delete User Photos
        private DeleteUsersPhotoPhotoService _deleteUsersPhotoPhotoService;
        public DeleteUsersPhotoPhotoService DeleteUsersPhotoPhotoService
        {
            get { return _deleteUsersPhotoPhotoService = _deleteUsersPhotoPhotoService ?? new DeleteUsersPhotoPhotoService(_context); }
        }        
        // Add User Photos Comment
        private PostUsersPhotoCommentService _postUsersPhotoCommentService;
        public PostUsersPhotoCommentService PostUsersPhotoCommentService
        {
            get { return _postUsersPhotoCommentService = _postUsersPhotoCommentService ?? new PostUsersPhotoCommentService(_context,_imapper); }
        }
    }
}

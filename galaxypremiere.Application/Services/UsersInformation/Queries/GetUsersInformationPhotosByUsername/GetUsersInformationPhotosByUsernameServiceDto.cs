﻿namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationPhotosByUsername
{
    public class GetUsersInformationPhotosByUsernameServiceDto
    {
        public Guid Id { get; set; } // PhotoId
        public string Filename { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
    }
}

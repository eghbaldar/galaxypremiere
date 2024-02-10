using Microsoft.AspNetCore.Http;

namespace galaxypremiere.Application.Services.UploadSmallFiles
{
    public class RequestUploadSmallFilesServiceDto
    {
        public string DirectoryNameLevelParent { get; set; } // Y=> wwwroot + Y 
        public string DirectoryNameLevelChild { get; set; } // X=> wwwroot + Y + X
        public IFormFile File { get; set; }
        public string[] Exension { get; set; } // acceptable extension
        public string FileSize { get; set; } // acceptable fileSize
        public long UsersId { get; set; }
    }
}

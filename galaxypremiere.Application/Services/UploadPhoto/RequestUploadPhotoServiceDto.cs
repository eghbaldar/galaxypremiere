using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UploadPhoto
{
    public class RequestUploadPhotoServiceDto
    {
        public string DirectoryNameLevelParent { get; set; } // Y=> wwwroot + Y 
        public string DirectoryNameLevelChild { get; set; } // X=> wwwroot + Y + X
        public IFormFile File { get; set; }
        public string[] Exension { get; set; } // acceptable extension
        public string FileSize { get; set; } // acceptable fileSize
        public long UsersId { get; set; }
        public Dictionary<string, string> Dimensions { get; set; }
        // for example, if we want to create to photos with different scales, we have to send: "{'original','550'},{'thumb','150'}}"
        // but if you desire to have one photo just pass a dimension: "{'original','550'}}"
        // 150 is width, and height is defined automatically based on its aspect ratio.
        // original and thumb are only samples to name those dimensions, not more.
    }
}

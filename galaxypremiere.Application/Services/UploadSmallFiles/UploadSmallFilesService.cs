using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UploadSmallFiles
{
    public class UploadSmallFilesService
    {
        public ResultUploadDto UploadFile(RequestUploadSmallFilesServiceDto req)
        {
            // check file ....
            if (req.File == null || req.File.Length == 0)
            {
                return new ResultUploadDto
                {
                    Success = false,
                    Message = "There is not file",
                    Filename = "",
                };
            }
            // check extension ....
            FileInfo info = new FileInfo(req.File.FileName);
            if (Array.IndexOf(req.Exension, info.Extension.ToLower()) < 0)
            {
                return new ResultUploadDto
                {
                    Success = false,
                    Message = $"File extension (${Array.IndexOf(req.Exension, info.Extension.ToLower())}) is unacceptable",
                    Filename = "",
                };
            }
            // check size ....
            if (req.File.Length > Convert.ToInt64(req.FileSize))
            {
                return new ResultUploadDto
                {
                    Success = false,
                    Message = $"File must be less than {int.Parse(req.FileSize)/ 1048576} Mb", // 1024*1024=1048576
                    Filename = "",
                };
            }
            // create folder ...
            string folder= $@"wwwroot\SiteTemplate\innerpages\" + 
                req.DirectoryNameLevelParent + @"\" + 
                req.DirectoryNameLevelChild;
            var uploadRootFolder = Path.Combine(Environment.CurrentDirectory, folder);
            if (!Directory.Exists(uploadRootFolder))
            {
                Directory.CreateDirectory(uploadRootFolder);
            }
            // create a unique file name ...
            string filename = DateTime.Now.Ticks.ToString() + req.File.FileName;
            // copy file ...
            var filePath = Path.Combine(uploadRootFolder, filename);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                req.File.CopyTo(fileStream);
            }

            return new ResultUploadDto
            {
                Success = true,
                Message="File is uploaded succesfully",
                Filename = filename,
            };
        }
    }
}

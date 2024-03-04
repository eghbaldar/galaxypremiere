using galaxypremiere.Application.Services.UploadSmallFiles;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UploadPhoto
{
    public class UploadPhotoService
    {
        public ResultUploadDto UploadFile(RequestUploadPhotoServiceDto req)
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
            if (Array.IndexOf(req.Extension, info.Extension.ToLower()) < 0)
            {
                return new ResultUploadDto
                {
                    Success = false,
                    Message = $"File extension (${Array.IndexOf(req.Extension, info.Extension.ToLower())}) is unacceptable",
                    Filename = "",
                };
            }
            // check size ....
            if (req.File.Length > Convert.ToInt64(req.FileSize))
            {
                return new ResultUploadDto
                {
                    Success = false,
                    Message = $"File must be less than {int.Parse(req.FileSize) / 1048576} Mb", // 1024*1024=1048576
                    Filename = "",
                };
            }
            // create folder ...
            string folder = $@"wwwroot\SiteTemplate\innerpages\" +
                req.DirectoryNameLevelParent + @"\" +
                req.DirectoryNameLevelChild;
            var uploadRootFolder = Path.Combine(Environment.CurrentDirectory, folder);
            if (!Directory.Exists(uploadRootFolder)) Directory.CreateDirectory(uploadRootFolder);
            //string filename = DateTime.Now.Ticks.ToString() + "-" + req.UsersId + info.Extension.ToLower();
            //var filePath = Path.Combine(uploadRootFolder, filename);
            string filename;
            using (MemoryStream memoryStream = new MemoryStream())
            { 
                req.File.CopyTo(memoryStream);// Copy the file contents to the MemoryStream
                memoryStream.Position = 0;// Reset the position of the MemoryStream to the beginning
                // Now you can use the MemoryStream as needed
                // For example, you can pass it to the SaveImageFromMemoryStream method
                filename = SaveImageFromMemoryStream(
                    memoryStream,
                    req.UsersId,
                    info.Extension.ToLower(),
                    req.Scales,
                    uploadRootFolder);
            }
            return new ResultUploadDto
            {
                Success = true,
                Message = "File is uploaded succesfully",
                Filename = filename,
            };
        }

        public string SaveImageFromMemoryStream(
            MemoryStream memoryStream,
            long userId,
            string extension,
            Dictionary<string, string> scales,
            string uploadPath
            )
        {
            using (Image image = Image.FromStream(memoryStream))
            {
                string firstPartOfFilename = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}-{DateTime.Now.Ticks.ToString()}-{userId.ToString()}";
                for(int i = 0;i < scales.Count; i++)
                {
                    string uniqueFileName = $"{firstPartOfFilename}-{scales.ElementAt(i).Key}{extension}"; // Guid.NewGuid().ToString() + ".jpg";
                    string imagePath = $"{uploadPath}/{uniqueFileName}";
                    int Width = int.Parse(scales.ElementAt(i).Value);
                    int Height = (int)Math.Round(image.Height * ((double)Width / image.Width));
                    using (Bitmap bitmap = new Bitmap(image))
                    {
                        using (Bitmap resizedBitmap = new Bitmap(bitmap, new Size(Width, Height)))
                        {
                            resizedBitmap.Save(imagePath);  // Save the resized image to the specified path
                        }
                    }

                }
                return firstPartOfFilename;
            }
        }
    }
}

using galaxypremiere.Common.DTOs;
using SixLabors.ImageSharp.Formats;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UploadSmallFiles
{
    public class UploadSmallFilesService
    {
        public ResultUploadDto UploadFile(RequestUploadSmallFilesServiceDto req)
        {
            // check file ...
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
                    Message = $"File must be less than {int.Parse(req.FileSize) / 1048576} Mb", // 1024*1024=1048576
                    Filename = "",
                };
            }
            // create folder ...
            string folder = $@"wwwroot\SiteTemplate\innerpages\" +
                req.DirectoryNameLevelParent + @"\" +
                req.DirectoryNameLevelChild;
            var uploadRootFolder = Path.Combine(Environment.CurrentDirectory, folder);
            if (!Directory.Exists(uploadRootFolder))
            {
                Directory.CreateDirectory(uploadRootFolder);
            }
            // create a unique file name ...
            string filename = DateTime.Now.Ticks.ToString() + "-" + req.UsersId + info.Extension.ToLower();
            // copy file ...
            var filePath = Path.Combine(uploadRootFolder, filename);
            //using (var fileStream = new FileStream(filePath, FileMode.Create))
            //{
            //    req.File.CopyTo(fileStream);
            //}
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Copy the file contents to the MemoryStream
                req.File.CopyTo(memoryStream);

                // Reset the position of the MemoryStream to the beginning
                memoryStream.Position = 0;

                // Now you can use the MemoryStream as needed
                // For example, you can pass it to the SaveImageFromMemoryStream method
                SaveImageFromMemoryStream(memoryStream);
            }

            return new ResultUploadDto
            {
                Success = true,
                Message = "File is uploaded succesfully",
                Filename = filename,
            };
        }

        public void SaveImageFromMemoryStream(MemoryStream memoryStream)
        {
            // Load the image from the MemoryStream
            using (Image image = Image.FromStream(memoryStream))
            {
                // Generate a unique file name
                string uniqueFileName = Guid.NewGuid().ToString() + ".jpg";

                // Determine the path where you want to save the image
                string imagePath = Path.Combine($@"wwwroot\SiteTemplate\innerpages\", uniqueFileName);
                // Calculate the new width and height based on the desired percentage
                // Calculate the new dimensions based on the desired width and the aspect ratio
                int newWidth = 150;
                int newHeight = (int)Math.Round(image.Height * ((double)newWidth / image.Width));

                // Resize the image if desired
                using (Bitmap bitmap = new Bitmap(image))
                {
                    using (Bitmap resizedBitmap = new Bitmap(bitmap, new Size(newWidth, newHeight)))
                    {
                        // Save the resized image to the specified path
                        resizedBitmap.Save(imagePath);
                    }
                }
            }
        }
    }
}

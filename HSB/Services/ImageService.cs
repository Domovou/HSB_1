using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HSB.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HSB.Services
{
    public class ImageService : IImageService
    {
        private IHostingEnvironment _hostingEnvironment;

        public ImageService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<string> UploadImage(Story story, IFormFile image)
        {
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads\\stories");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            if (image.Length > 0)
            {
                string fileName = $"{DateTime.Now.ToShortDateString()}/{image.FileName}";
                string validFileName = MakeValidFileName(fileName);
                using (var fileStream = new FileStream(Path.Combine(uploads, validFileName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                    story.ImagePath = $"~/uploads/stories/{validFileName}";
                    
                }
            }
            return story.ImagePath;
        }
        
        private static string MakeValidFileName(string name)
        {
            string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
        }

        public Task DeleteImage(string imagePath)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, 
                                    "uploads\\stories\\", imagePath.Substring(18));

           
            File.Delete(path); 
            return Task.CompletedTask;
           
        }
    }
}

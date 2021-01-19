using HSB.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HSB.Services
{
   public  interface IImageService
   {
       Task<string> UploadImage(Story story, IFormFile image);

       Task DeleteImage(string imagePath);
   }
}

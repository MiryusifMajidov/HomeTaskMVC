using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediClub.BL.CustomExtention
{
    public static class FileUploadExtensions
    {

        public static async Task<string> UploadFile(this IFormFile file, string uploadFolder)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Fayl mövcud deyil və ya boşdur.");
            }

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            return uniqueFileName;
        }
    }
}

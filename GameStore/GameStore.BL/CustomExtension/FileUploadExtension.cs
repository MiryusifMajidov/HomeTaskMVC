using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BL.CustomExtension
{
    public static class FileUploadExtension
    {
        private static bool FileIsTrue(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return false;
            }
            return true;
        }

        public static async Task<string> FileUpload(this IFormFile file, string FolderPath, int MaxFileLenght)
        {

            if (FileIsTrue(file) == false)
            {
                if (file.Length > MaxFileLenght * 1024 * 1024)
                {
                    throw new ArgumentException("Fayl mövcud deyil və ya boşdur.");
                }
            }



            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), FolderPath);

            IsFolder(uploadFolder);



            var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);

            }


            return uniqueFileName;
        }

        private static void IsFolder(string a)
        {
            if (!Directory.Exists(a))
            {
                Directory.CreateDirectory(a);
            }
        }

        public static void IsTrueType(this IFormFile file, string FileType)
        {

            var supportedTypes = ("txt", "doc", "docx", "pdf", "xls", "xlsx");

            var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);



        }
    }
}

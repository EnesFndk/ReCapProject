using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileUpload
    {
        public static string Add(IFormFile image)
        {

            if (image == null)
            {
                return "default.png";

            }

            string directory = Environment.CurrentDirectory + @"\wwwroot\";
            string fileName = CreateNewFileName(image.FileName);

            string path = Path.Combine(directory, "Images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                image.CopyTo(stream);
            }

            string filePath = Path.Combine(path, fileName);
            return fileName;
        }

        public static string CreateNewFileName(string fileName)
        {
            string[] file = fileName.Split('.');
            string extension = file[1];
            string newFileName = string.Format(@"{0}." + extension, Guid.NewGuid());
            return newFileName;
        }

        public static bool Delete(string path)
        {
            try
            {
                File.Delete(path);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}

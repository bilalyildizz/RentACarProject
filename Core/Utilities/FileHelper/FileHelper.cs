using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {

        public static  string Add(IFormFile files)
        {
            if (files.Length > 0)
            {
                var createPath = FolderAndFilePath(files);

                if (!CreateFolder(createPath.folderPath))
                {
                    Directory.CreateDirectory(createPath.folderPath);
                }
                using (FileStream stream = File.Create(createPath.filePath))
                {
                    files.CopyTo(stream);
                    stream.Flush();
                    return "";
                }

            }
            else
            {
                return "";
            }

        }
        private static (string fileName, string folderPath, string lowerFolderPath, string filePath) FolderAndFilePath(IFormFile files)
        {
            string extension = Path.GetExtension(files.FileName);
            string fileName = Guid.NewGuid().ToString(format: "D") + extension;
            string folderPath = Path.Combine(Environment.CurrentDirectory, @"wwwroot\");
            string lowerFolderPath = @"Images\";
            string filePath = Path.Combine(folderPath, lowerFolderPath, fileName);

            return (fileName, folderPath, lowerFolderPath, filePath);
        }
        public static bool CreateFolder(string folderPath)
        {

            return Directory.Exists(folderPath);

        }

        public static string CreateFilePath(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            string path = Environment.CurrentDirectory + @"\wwwroot\" + @"Images\";
            string guidPath = Guid.NewGuid().ToString() + fileExtension;

            string fullPath = Path.Combine(path, guidPath);
            return fullPath;


        }
    }
}

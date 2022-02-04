using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelperr
    {


        public static string Add(IFormFile files)
        {
            if (files.Length > 0)
            {
                var fullPath = CreateFullPath(files);

                if (!CreateFolder(fullPath.folderPath))
                {
                    Directory.CreateDirectory(fullPath.folderPath);

                }

                using (FileStream stream = File.Create(fullPath.filePath))
                {
                    files.CopyTo(stream);
                    stream.Flush();
                    return fullPath.filePath;
                }


            }


            return "";


        }



        public static IResult Delete(string filePath)
        {
            try
            {
                File.Delete(filePath);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();

        }

        public static string Update(IFormFile files, string deleteFilePath)
        {

            var fullPath = CreateFullPath(files);

            using (FileStream stream = File.Create(fullPath.filePath))
            {
                files.CopyTo(stream);
                stream.Flush();
                
            }
            File.Delete(deleteFilePath);

            return fullPath.filePath;

        }





        private static bool CreateFolder(string folderPath)
        {
            return Directory.Exists(folderPath);

        }

        public static (string filePath, string folderPath) CreateFullPath(IFormFile file)
        {
            FileInfo info = new FileInfo(file.FileName);

            string folderPath = Environment.CurrentDirectory + @"\Images";
            string newPath = Guid.NewGuid().ToString() + info.Extension;

            string filePath = $@"{folderPath}\{newPath}";
            return (filePath, folderPath);




        }
    }
}

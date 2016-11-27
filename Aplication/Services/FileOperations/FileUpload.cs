using System;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Aplication.Services.FileOperations
{
    public static class FileUpload
    {
        public static string ReadStringFormFile(IFormFile file)
        {
            return System.Text.Encoding.UTF8.GetString(ReadBytesFormFile(file));
        }

        public static byte[] ReadBytesFormFile(IFormFile file)
        {
            using (var fileStream = file.OpenReadStream())
            {
                return ReadBytesFormStream(fileStream);
            }
        }

        public static byte[] ReadBytesFormStream(Stream fileStream) 
        {
            using (var ms = new MemoryStream())
            {
                fileStream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
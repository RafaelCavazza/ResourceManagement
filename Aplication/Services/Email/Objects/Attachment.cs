using System;
using System.IO;
using System.Linq;

namespace Aplication.Services.Email.Objects
{
    public class Attachment
    {
        public string Name {get; internal set;}
        public string Mimetype {get; internal set;}
        public byte[] Content {get; internal set;}

        public Attachment(string name, string mimetype, byte[] content)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new Exception("Parameter Name cannot be null, empty ou white spaces.");

            if(string.IsNullOrWhiteSpace(mimetype))
                throw new Exception("Parameter Mimetype cannot be null, empty ou white spaces.");
            
            if(content==null || !content.Any())
                throw new Exception("Parameter Content cannot be null or empty.");

            Name = name;
            Mimetype = mimetype;
            Content = content;
        }
        
        private static byte[] ReadStream(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}

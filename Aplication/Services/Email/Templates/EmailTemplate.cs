using System.Collections.Generic;
using System.IO;

namespace Aplication.Services.Email.Templates
{
    public static class EmailTemplate
    {
        private static string CurrentLocation = Directory.GetCurrentDirectory();

        public static string GetTemplate(string templateName, Dictionary<string, string> placeholders)
        {
            templateName = templateName.Replace(".html","");
            var templateLocation = CurrentLocation + "/HtmlTemplates/" + templateName + ".html";
            
            using (var reader = File.OpenText(templateLocation))
            {
                var fileContent = reader.ReadToEnd();
                foreach(var placeHolder in placeholders)
                {
                    var key = placeHolder.Key.Replace("{#","").Replace("}","");
                    key = "{#" +  key + "}";

                    fileContent = fileContent.Replace(key, placeHolder.Value);
                }
                return fileContent;
            }
        } 
    }
}

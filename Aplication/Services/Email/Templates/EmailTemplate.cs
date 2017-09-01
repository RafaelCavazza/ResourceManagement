using System.Collections.Generic;
using System.IO;

namespace Aplication.Services.Email.Templates
{
    public static class EmailTemplate
    {
        private static string CurrentLocation = Directory.GetCurrentDirectory();

        public static string GetTemplate(string templateName, Dictionary<string, string> placeholders)
        {
            var templateContent = ReadTemplate(templateName);
            return ReplaceTemplatePlaceHolders(templateContent, placeholders);
        } 

        private static string ReadTemplate(string templateName)
        {
            templateName = templateName.Replace(".html","");
            var templateLocation = CurrentLocation + "/HtmlTemplates/" + templateName + ".html";
            using (var reader = File.OpenText(templateLocation))
            {
                return reader.ReadToEnd();
            }
        }
 
        private static string ReplaceTemplatePlaceHolders(string templateContent, Dictionary<string, string> placeholders)
        {
            foreach(var placeHolder in placeholders)
            {
                var key = placeHolder.Key.Replace("{#","").Replace("}","");
                key = "{#" +  key + "}";
                templateContent = templateContent.Replace(key, placeHolder.Value);
            }
            return templateContent;
        }
    }
}

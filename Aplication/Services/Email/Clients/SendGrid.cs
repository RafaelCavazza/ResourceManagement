using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Aplication.Services.Email.Enums;
using Aplication.Services.Email.Interfaces;
using Newtonsoft.Json.Linq;

namespace Aplication.Services.Email.Clients
{
    public class SendGrid : IEmailSender
    {
        private readonly string _apiUrl = "https://api.sendgrid.com/v3/mail/send";
        public string ApiKey {get; internal set;}

        public SendGrid()
        {
            ApiKey = "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";
        }

        public string MountRequestBody(string from, List<string> to, string subject, string content, EmailContentType type)
        {
            var body = new JObject();
            var jPersonalizations = new JProperty("personalizations");
            var jFrom = new JProperty("from");
            var jTo = new JProperty("to");
            var jSubject = new JProperty("subject", subject);
            var jContent = new JProperty("content");
            var jValue = new JProperty("value",content);
            var jType = new JProperty("type");

            var toArray = new JArray();
            foreach(var email in to)
            {
                toArray.Add(new JObject(new JProperty("email", email)));
            }

            jTo.Value = toArray;
            jPersonalizations.Value = new JArray( new JObject(jTo,jSubject));
            
            if(type == EmailContentType.Text)
                jType.Value = "text/plain";
            else if(type == EmailContentType.Html)
                jType.Value = "text/html";
            
            jContent.Value = new JArray( new JObject( jType,jValue ) );
            jFrom.Value = new JObject( new JProperty("email",from)) ;

            body.Add(jPersonalizations);
            body.Add(jFrom);
            body.Add(jContent);
         
            return body.ToString();  
        }

        private void SetRequestHeaders(HttpRequestHeaders header)
        {
            header.Add("Authorization","Bearer "+ ApiKey);
        }

        public async void Send(string from, List<string> to, string subject, string body, EmailContentType contenType)
        {
            using (var client = new HttpClient())
            {
                var requestBody = MountRequestBody(from, to, subject, body, contenType);
                SetRequestHeaders(client.DefaultRequestHeaders);

                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(_apiUrl, content);
                var responseString = await response.Content.ReadAsStringAsync();
            }
        }
    }
}

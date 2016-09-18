using System;
using System.Collections.Generic;
using Services.Email.Interaces;
using Services.Email.Objects;

namespace Services.Email.Clients
{
    public class SendGrid : IEmailSender
    {
        private readonly string _apiUrl = "https://api.sendgrid.com/v3/mail/send";
        public string ApiKey {get; internal set;}
        public string Sender {get; internal set;}

        public SendGrid(string apiKey)
        {
            ApiKey = apiKey;
        }

        public SendGrid(string apiKey, string sender) : this(apiKey)
        {
            Sender = sender;
        }
    }
}

using System;
using System.Collections.Generic;
using Aplication.Services.Email.Objects;

namespace Aplication.Services.Email.Interaces
{
    public interface IEmailSender : IDisposable 
    {
        void Send(List<string> to, string subject, string body, EmailContentType contenType);
        void Send(List<string> to, List<string> cc, List<string> cco, string subject, string body, EmailContentType contenType);
        void Send(string sender,List<string> to, List<string> cc, List<string> cco, string subject, string body, EmailContentType contenType);
        void Send(string sender,List<string> to, List<string> cc, List<string> cco, string subject, string body, Attachment attachment, EmailContentType contenType);
    }

    public enum EmailContentType
    {
        Text,
        Html
    }
}

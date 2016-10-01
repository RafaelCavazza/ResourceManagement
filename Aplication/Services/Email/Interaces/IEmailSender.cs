using System.Collections.Generic;

namespace Aplication.Services.Email.Interaces
{
    public interface IEmailSender 
    {
        void Send(string from, List<string> to, string subject, string body, EmailContentType contenType);
    }

    public enum EmailContentType
    {
        Text,
        Html
    }
}

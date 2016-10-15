using System.Collections.Generic;
using Aplication.Services.Email.Enums;

namespace Aplication.Services.Email.Interaces
{
    public interface IEmailSender 
    {
        void Send(string from, List<string> to, string subject, string body, EmailContentType contenType);
    }
}

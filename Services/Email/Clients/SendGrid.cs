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

        public void Send(List<string> to, string subject, string body, EmailContentType contenType)
        {
            throw new NotImplementedException();
        }

        public void Send(List<string> to, List<string> cc, List<string> cco, string subject, string body, EmailContentType contenType)
        {
            throw new NotImplementedException();
        }

        public void Send(string sender, List<string> to, List<string> cc, List<string> cco, string subject, string body, EmailContentType contenType)
        {
            throw new NotImplementedException();
        }

        public void Send(string sender, List<string> to, List<string> cc, List<string> cco, string subject, string body, Attachment attachment, EmailContentType contenType)
        {
            throw new NotImplementedException();
        }

        private string MountRequestBody()
        {
            return null;
            //@"{"personalizations": [{"to": [{"email": "your.email@example.com"}]}],"from": {"email": "example@example.com"},"subject": "Hello, World!","content": [{"type": "text/plain", "value": "Heya!"}]}";            
        }

        private void SetRequestHeaders()
        {

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SendGrid() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}

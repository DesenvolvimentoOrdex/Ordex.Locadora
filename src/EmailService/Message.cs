using EmailService;
using Microsoft.AspNetCore.Http;
using MimeKit;



namespace Ordex.Locadora.Service.EmailService
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public IFormFileCollection Attachments { get; set; }

        public Message(IEnumerable<MailboxAddress> to, string subject, string content, IFormFileCollection attachments)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress(x.Name, x.Address)));
            Subject = subject;
            Content = content;
            Attachments = attachments;
        }
    }
}

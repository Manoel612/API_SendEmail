using SendEmail.Models;

namespace SendEmail.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(MessageModel message);
    }
}

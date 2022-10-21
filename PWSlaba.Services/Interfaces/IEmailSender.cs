using System.Threading.Tasks;

namespace PWSlaba.Services.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string To, string ToName, string Subject, string Body);
    }
}

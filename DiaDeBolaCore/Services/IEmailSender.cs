using System.Threading.Tasks;

namespace DiaDeBolaCore.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}

using System.Threading.Tasks;

namespace DiaDeBolaCore.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}

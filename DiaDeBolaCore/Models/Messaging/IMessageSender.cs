namespace DiaDeBolaCore.Models
{
    public interface IMessageSender
    {
        public void SendMessage(Player player, string messageSubject, string messageBody);

    }
}

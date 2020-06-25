namespace DiaDeBolaClassLibrary
{
    public interface IMessageSender
    {
        public void SendMessage(IPlayer player, string messageSubject, string messageBody);

    }
}

namespace DiaDeBolaCore.Models
{
    public class AdminInEvent
    {
        public int Id { get; set; }
        public Event Event { get; set; }
        public Player Admin { get; set; }
    }
}

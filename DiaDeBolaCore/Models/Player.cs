namespace DiaDeBolaCore.Models
{
    public class Player
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }

        public PlayerStatus Status { get; set; }
    }
}

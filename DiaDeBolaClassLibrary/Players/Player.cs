using static DiaDeBolaClassLibrary.Enums;

namespace DiaDeBolaClassLibrary
{
    public class Player : IPlayer
    {
        public PlayerStatus Status { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        PlayerStatus IPlayer.Status { get; set; }

        public Player()
        {
            Status = PlayerStatus.NotContacted;
        }

        public Player(string email) 
        {
            Email = email;
            Status = PlayerStatus.NotContacted;
        }

        public void SetFullName()
        {
            FullName = $"{FirstName} {LastName}";
        }
    }
}

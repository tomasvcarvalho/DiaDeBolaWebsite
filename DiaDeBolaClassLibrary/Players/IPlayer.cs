using static DiaDeBolaClassLibrary.Enums;

namespace DiaDeBolaClassLibrary
{
    public interface IPlayer : IRegisteredUser
    {
        public PlayerStatus Status { get; set; }
    }
}

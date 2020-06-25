using System;

namespace DiaDeBolaClassLibrary
{
    public interface IAdmin : IPlayer
    {
        void SetNewDateTime(IEvent gameEvent, DateTime newDateTime);

        void SetNewMaxNumberOfPlayers(IEvent gameEvent, int newMaxNumberOfPlayers);
        void SetPlayerTeam(IEvent gameEvent, IPlayer player, ITeam team);

        void SetNewGameLocation(IEvent gameEvent, Location newLocation);

    }
}

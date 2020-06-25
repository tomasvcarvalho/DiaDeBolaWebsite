using System;

namespace DiaDeBolaClassLibrary
{
    public class Admin : IAdmin
    {
        public Enums.PlayerStatus Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FullName { get ; set ; }

        public Admin()
        {
            Status = Enums.PlayerStatus.NotContacted;
        }

        public Admin(string email) 
        {
            Email = email;
            Status = Enums.PlayerStatus.NotContacted;
        }
        
        public void SetNewDateTime(IEvent gameEvent, DateTime newDateTime)
        {
            gameEvent.DateTime = newDateTime;
        }

        public void SetNewGameLocation(IEvent gameEvent, Location newLocation)
        {
            gameEvent.Location = newLocation;
        }

        public void SetNewMaxNumberOfPlayers(IEvent gameEvent, int newMaxNumberOfPlayers)
        {
            gameEvent.MaxNumberOfPlayers = newMaxNumberOfPlayers;
        }

        public void SetPlayerTeam(IEvent gameEvent, IPlayer player, ITeam team)
        {
            var playerCurrentTeam = gameEvent.GetPlayersTeam(player);

            if (playerCurrentTeam != team) 
            {
                playerCurrentTeam.RemovePlayer(player);
            }

            team.AddPlayer(player);
        }

        public void SetFullName()
        {
            FullName = $"{FirstName} {LastName}";
        }
    }
}

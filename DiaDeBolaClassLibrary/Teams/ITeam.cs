using System.Collections.Generic;
using static DiaDeBolaClassLibrary.Enums;

namespace DiaDeBolaClassLibrary
{
    public interface ITeam
    {
        string Name { get; set; }
        List<IPlayer> Members { get; set; }

        EquipmentColor EquipmentColor { get; set; }

        int MaxNumberOfPlayers { get; set; }

        public bool IsPlayerInTeam(IPlayer player);

        public void AddPlayer(IPlayer player);
        public void RemovePlayer(IPlayer player);
    }
}

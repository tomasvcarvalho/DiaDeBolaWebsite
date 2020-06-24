using System;
using System.Collections.Generic;
using System.Text;

namespace DiaDeBolaClassLibrary
{
    public static class Enums
    {
        public enum EquipmentColor
        {
            NotAttributed,
            White,
            DarkColor,
            Black,
            Yellow
        }

        public enum PlayerStatus
        {
            NotAttributed,
            NotContacted,
            Contacted,
            Plays,
            DoesNotPlay,
            PlaysIfPossible,
            PlaysIfNeeded
        }
    }
}

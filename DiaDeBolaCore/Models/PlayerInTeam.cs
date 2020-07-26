using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaDeBolaCore.Models
{
    public class PlayerInTeam
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public ApplicationUser Player { get; set; }
        public PlayerStatus PlayerStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaDeBolaCore.Models
{
    public class AdminInEvent
    {
        public int Id { get; set; }
        public Event Event { get; set; }
        public Player Admin { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiaDeBolaCore.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentColor EquipmentColor { get; set; }
        public int EquipmentColorId { get; set; }
    }
}

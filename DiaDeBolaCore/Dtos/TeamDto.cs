using System.Collections.Generic;

namespace DiaDeBolaCore.Dtos
{
    public class TeamDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public EquipmentColorDto EquipmentColor { get; set; }

        public List<PlayerDto> Players { get; set; }
    }
}

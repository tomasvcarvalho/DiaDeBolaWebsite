using System.Collections.Generic;

namespace DiaDeBolaCore.Dtos
{
    public class ContactListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<int> ContactIds { get; set; }
    }
}

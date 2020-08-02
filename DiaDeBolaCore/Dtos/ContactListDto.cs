using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaDeBolaCore.Dtos
{
    public class ContactListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> ContactIds { get; set; }
        public string UserEmail{ get; set; }
    }
}

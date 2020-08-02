using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaDeBolaCore.Models
{
    public class ContactList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; }
        public int NumberOfElements { get; set; }
        public ApplicationUser User { get; set; }
    }
}

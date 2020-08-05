using System.Collections.Generic;

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

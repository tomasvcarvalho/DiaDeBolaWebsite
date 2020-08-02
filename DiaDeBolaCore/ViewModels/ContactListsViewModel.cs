using DiaDeBolaCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaDeBolaCore.ViewModels
{
    public class ContactListsViewModel
    {
        public List<Contact> Contacts{ get; set; }
        public List<ContactList> ContactLists { get; set; }

    }
}

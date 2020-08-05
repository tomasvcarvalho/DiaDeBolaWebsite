using DiaDeBolaCore.Dtos;
using System.Collections.Generic;

namespace DiaDeBolaCore.ViewModels
{
    public class ContactListsViewModel
    {
        public List<ContactDto> Contacts { get; set; }
        public List<ContactListDto> ContactLists { get; set; }

    }
}

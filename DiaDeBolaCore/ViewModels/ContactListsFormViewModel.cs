using DiaDeBolaCore.Dtos;
using System.Collections.Generic;

namespace DiaDeBolaCore.ViewModels
{
    public class ContactListsFormViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<ContactDto> ContactDtos { get; set; }

        public ContactListsFormViewModel()
        {
            Id = 0;
        }
    }
}

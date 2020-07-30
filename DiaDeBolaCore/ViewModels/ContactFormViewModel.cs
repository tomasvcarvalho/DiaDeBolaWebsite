using DiaDeBolaCore.Dtos;
using DiaDeBolaCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiaDeBolaCore.ViewModels
{
    public class ContactFormViewModel
    {
        public int? Id { get; set; }

        public ApplicationUserDto User { get; set; }

        [DisplayName("Friend's Email")]
        [Required]
        [ExistingUser]
        [EmailAddress]
        public string FriendEmail { get; set; }
        public string UserId { get; set; }


        public ContactFormViewModel()
        {
            Id = 0;
        }
    }
}

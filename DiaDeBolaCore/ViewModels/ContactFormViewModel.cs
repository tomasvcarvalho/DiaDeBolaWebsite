using DiaDeBolaCore.Dtos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DiaDeBolaCore.ViewModels
{
    public class ContactFormViewModel
    {
        public int? Id { get; set; }

        public ApplicationUserDto User { get; set; }

        [DisplayName("Friend's Email")]
        [Required]
        [Models.ExistingUser]
        [EmailAddress]
        public string FriendEmail { get; set; }
        public string UserId { get; set; }


        public ContactFormViewModel()
        {
            Id = 0;
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DiaDeBolaCore.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public ApplicationUser Friend { get; set; }


    }
}

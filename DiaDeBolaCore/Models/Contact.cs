using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiaDeBolaCore.Models
{
    public class Contact
    {
        public int Id { get; set;  }
        
        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public ApplicationUser Friend { get; set; }


    }
}

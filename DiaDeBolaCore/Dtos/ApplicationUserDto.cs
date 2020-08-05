using System.ComponentModel.DataAnnotations;

namespace DiaDeBolaCore.Dtos
{
    public class ApplicationUserDto
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName{ 
            get 
            { 
                return FirstName + " " + LastName; 
            } 
        }
        
        public string Email { get; set; }
    }
}

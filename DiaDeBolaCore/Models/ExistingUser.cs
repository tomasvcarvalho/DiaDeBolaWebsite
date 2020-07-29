using DiaDeBolaCore.Dtos;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiaDeBolaCore.Models
{
    public class ExistingUser : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var contactDto = (ContactDto)validationContext.ObjectInstance;

            var _context = (ApplicationDbContext)validationContext
                         .GetService(typeof(ApplicationDbContext));

            var userExists = _context.WebsiteUsers.Any(u => u.Email == contactDto.Friend.Email);

            return userExists ? ValidationResult.Success : 
                new ValidationResult("User is not registered in DiaDeBola.");
        }
    }
}

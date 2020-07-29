using DiaDeBolaCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaDeBolaCore.Dtos
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUserDto User { get; set; }
        public string FriendId { get; set; }

        [ExistingUser]
        public ApplicationUserDto Friend { get; set; }

    }
}

﻿namespace DiaDeBolaCore.Dtos
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUserDto User { get; set; }
        public string FriendId { get; set; }
        public ApplicationUserDto Friend { get; set; }

    }
}

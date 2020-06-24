using System;
using System.Collections.Generic;
using System.Text;

namespace DiaDeBolaClassLibrary
{
    public interface IRegisteredUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public void SetFullName();
    }
}

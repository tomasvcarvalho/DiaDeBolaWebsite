using AutoMapper;
using DiaDeBolaCore.Dtos;
using DiaDeBolaCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace DiaDeBolaCore.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ContactsController(ILogger<ContactsController> logger, IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }


        // GET /api/contacts/id
        [HttpGet("{userId}")]
        public IActionResult GetContacts(string userId, string query = null)
        {
            var userContactsQuery = _context.Contacts
                .Include(u => u.Friend)
                .Where(u => u.User.Id == userId);


            var userContactDtos = userContactsQuery
               .Select(_mapper.Map<Contact, ContactDto>);

            if (!String.IsNullOrWhiteSpace(query))
                userContactDtos = userContactDtos.Where(c => c.Friend.FullName.Contains(query, StringComparison.InvariantCultureIgnoreCase));

            return Ok(userContactDtos);
        }


        // DELETE /api/contacts/Id
        [HttpDelete("{id:int}")]
        public IActionResult DeleteContact(int id)
        {
            var contactInDb = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if (contactInDb == null)
                return NotFound();

            _context.Contacts.Remove(contactInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}

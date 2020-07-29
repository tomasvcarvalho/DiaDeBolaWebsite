using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiaDeBolaCore.Dtos;
using DiaDeBolaCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DiaDeBolaCore.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private ApplicationDbContext _context;
        private IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ContactsController(ILogger<ContactsController> logger, IMapper mapper, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        // GET /api/contacts/id
        [HttpGet("{id}")]
        public IActionResult GetContacts(string id) 
        {
            var userContacts = _context.Contacts
                .Include(u => u.Friend)
                .Where(u => u.User.Id == id)
                .ToList();

            var userContactDtos = userContacts
               .Select(_mapper.Map<Contact, ContactDto>);

            return Ok(userContactDtos);
        }


        // POST /api/contacts/
        [HttpPost]
        public IActionResult CreateContact(ContactDto contactDto)
        {
            var existingUsers = _context.WebsiteUsers
               .Where(u => u.Email == contactDto.Friend.Email)
               .ToList();

            if (existingUsers.Count == 0)
                return BadRequest("Contact is not registered in DiaDeBola.");

            var userContacts = _context.Contacts
                .Where(u => u.User.Id == contactDto.UserId && u.Friend.Id == contactDto.FriendId)
                .ToList();

            if (userContacts.Count > 0)
                return BadRequest("Contact already exists.");

            var contact = _mapper.Map<ContactDto, Contact>(contactDto);
            _context.Contacts.Add(contact);
            _context.SaveChanges();

            contactDto.Id = contact.Id;

            return Created(new Uri(Request.GetDisplayUrl() + "/" + contact.Id), contactDto);
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

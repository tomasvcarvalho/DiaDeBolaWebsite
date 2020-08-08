using AutoMapper;
using DiaDeBolaCore.Dtos;
using DiaDeBolaCore.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace DiaDeBolaCore.Controllers.Api
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactListsController : ControllerBase
    {
        private readonly ILogger<ContactListsController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ContactListsController(ILogger<ContactListsController> logger, IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }

        // GET /api/contactLists/id
        [HttpGet("{userId}")]
        public IActionResult GetContactLists(string userId)
        {
            var userContactLists = _context.ContactLists
                .Where(u => u.User.Id == userId)
                .ToList();

            var userContactListDtos = userContactLists
               .Select(_mapper.Map<ContactList, ContactListDto>);

            return Ok(userContactListDtos);
        }


        // DELETE /api/contactLists/Id
        [HttpDelete("{id:int}")]
        public IActionResult DeleteContactList(int id)
        {
            var contactListInDb = _context.ContactLists.SingleOrDefault(c => c.Id == id);

            if (contactListInDb == null)
                return NotFound();

            _context.ContactLists.Remove(contactListInDb);
            _context.SaveChanges();
            return Ok();
        }


        // POST /api/contactLists
        [HttpPost]
        public IActionResult CreateContactList(string userId, ContactListDto contactListDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();



            var contactList = new ContactList()
            {
                Name = contactListDto.Name,
                NumberOfElements = contactListDto.ContactIds.Count(),
                User = _context.WebsiteUsers.SingleOrDefault(u => u.Id == userId),
                Contacts = _context.Contacts.Where(c => contactListDto.ContactIds.Contains(c.Id)).ToList()
            };
            _context.ContactLists.Add(contactList);



            _context.SaveChanges();

            contactListDto.Id = contactList.Id;
            return Created(new Uri(Request.GetEncodedUrl() + "/" + contactList.Id), contactListDto);
        }
    }
}

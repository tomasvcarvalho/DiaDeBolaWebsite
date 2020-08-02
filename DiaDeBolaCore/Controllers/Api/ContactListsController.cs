using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiaDeBolaCore.Data.Migrations;
using DiaDeBolaCore.Dtos;
using DiaDeBolaCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiaDeBolaCore.Controllers.Api
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ContactListsController : ControllerBase
    {
        private readonly ILogger<ContactListsController> _logger;
        private ApplicationDbContext _context;
        private IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ContactListsController(ILogger<ContactListsController> logger, IMapper mapper, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult CreateContactList(ContactListDto contactListDto) 
        {
            var user = _context.WebsiteUsers.SingleOrDefault(u => u.Email == contactListDto.UserEmail);

            var contactList = new ContactList()
            {
                Name = contactListDto.Name,
                Contacts = _context.Contacts
                .Where(c=> 
                    contactListDto.ContactIds.Contains(c.Id))
                .ToList(),
                User = user
            };
            
            _context.ContactLists.Add(contactList);

            return Created(new Uri(Request.GetDisplayUrl() + "/" + contactList.Id), contactListDto);
        }

    }
}

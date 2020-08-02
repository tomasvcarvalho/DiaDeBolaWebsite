using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiaDeBolaCore.Dtos;
using DiaDeBolaCore.Models;
using DiaDeBolaCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiaDeBolaCore.Controllers
{
    [Authorize]
    public class ContactsController : Controller
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

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var userContacts = _context.Contacts
                .Where(u => u.User.Id == user.Id)
                .ToList();

            var userContactDtos = userContacts
               .Select(_mapper.Map<Contact, ContactDto>);


            return View("List", userContactDtos);
        }

        
        public IActionResult New()
        {
            return View("ContactForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ContactFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var newViewModel = new ContactFormViewModel()
                {
                    User = viewModel.User,
                    UserId = viewModel.UserId,
                    FriendEmail = viewModel.FriendEmail
                };
                return View("ContactForm", viewModel);
            }

            var user = await _userManager.GetUserAsync(User);

            if (user.Email == viewModel.FriendEmail)
                return BadRequest("User cannot add itself as a contact.");

            var userContacts = _context.Contacts
                .Where(u => u.User.Id == user.Id && u.Friend.Email == viewModel.FriendEmail)
                .ToList();

            if (userContacts.Count > 0)
                return BadRequest("Contact already exists.");

            var friend = _context.WebsiteUsers
                .SingleOrDefault(u => u.Email == viewModel.FriendEmail);

            var contact = new Contact() 
            { 
                User = user,
                Friend = friend
            };

            _context.Contacts.Add(contact);
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Contacts");
        }
    }
}

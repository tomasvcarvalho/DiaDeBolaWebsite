using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiaDeBolaCore.Dtos;
using DiaDeBolaCore.Models;
using DiaDeBolaCore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiaDeBolaCore.Controllers
{
    public class ContactListsController : Controller
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


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var userContactLists = _context.ContactLists
                .Where(u => u.User.Id == user.Id)
                .ToList();

            var userContactListDtos = userContactLists
               .Select(_mapper.Map<ContactList, ContactListDto>);

            return View("List", userContactListDtos);
        }


        public async Task<IActionResult> New()
        {
            var user = await _userManager.GetUserAsync(User);
            var userContacts = _context.Contacts
            .Where(u => u.User.Id == user.Id)
            .ToList();

            var userContactLists = _context.ContactLists
            .Where(u => u.User.Id == user.Id)
            .ToList();

            var viewModel = new ContactListsViewModel()
        {
            Contacts = userContacts,
            ContactLists = userContactLists

        };

            return View("ContactListForm", viewModel);
    }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ContactListsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var newViewModel = new ContactListsFormViewModel()
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    ContactDtos = viewModel.ContactDtos
                };
                return View("ContactListForm", viewModel);
            }

            var user = await _userManager.GetUserAsync(User);

            var userContactLists = _context.ContactLists
                .Where(u => u.Name == viewModel.Use)
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

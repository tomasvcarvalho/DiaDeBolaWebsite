using AutoMapper;
using DiaDeBolaCore.Dtos;
using DiaDeBolaCore.Models;
using DiaDeBolaCore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace DiaDeBolaCore.Controllers
{
    public class ContactListsController : Controller
    {
        private readonly ILogger<ContactListsController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
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
            var userContactDtos = _context.Contacts
            .Where(u => u.User.Id == user.Id)
            .Select(_mapper.Map<Contact, ContactDto>)
            .ToList();

            var userContactListDtos = _context.ContactLists
            .Where(u => u.User.Id == user.Id)
            .Select(_mapper.Map<ContactList, ContactListDto>)
            .ToList();

            var viewModel = new ContactListsViewModel()
            {
                Contacts = userContactDtos,
                ContactLists = userContactListDtos

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
                .Where(u => u.Name == viewModel.Name)
                .ToList();

            if (userContactLists.Count > 0)
                return BadRequest("Contact List with the same name already exists.");



            var contactList = new ContactList()
            {
                User = user,
                Contacts = viewModel.ContactDtos.Select(_mapper.Map<ContactDto, Contact>).ToList(),
                NumberOfElements = viewModel.ContactDtos.Count
            };

            _context.ContactLists.Add(contactList);
            _context.SaveChanges();

            return RedirectToAction("Index", "Contacts");
        }
    }
}

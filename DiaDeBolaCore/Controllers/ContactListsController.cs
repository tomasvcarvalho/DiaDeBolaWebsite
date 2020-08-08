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


        public IActionResult New()
        {
            return View("ContactListForm");
        }
    }
}

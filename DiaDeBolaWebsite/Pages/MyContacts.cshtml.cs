using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DiaDeBolaWebsite.Pages
{
    public class MyContactsModel : PageModel
    {
        public List<string> ContactList { get; set; }
        
        public void OnGet()
        {

        }
    }
}
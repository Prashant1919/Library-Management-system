using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudeoperationsonRazorPages.Pages.Demo
{
    public class UIModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        public int age { get; set; }

        public string greeting { get; set; }

        public void OnGet()
        {
            ViewData["Message"] = "This is studenit registration form";
            greeting = "Enter Your name ";
        }
        public IActionResult OnPost()
        {
            greeting = "Hello" + Name;
            TempData["Message"] = "Hello" + Name+"Your form submitted successfully";
            return RedirectToPage("/Account/SignIn");
        }
    }
}

using CrudeoperationsonRazorPages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudeoperationsonRazorPages.Pages.Account
{
    public class SignInModel : PageModel
    { 
        private readonly MYDBContext _context;
        public SignInModel(MYDBContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public bool RememberMe { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {                
                return Page();
            }
            var user = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.Email == Email && u.Password == Password);
            if(user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
            // Store user in session
            HttpContext.Session.SetString("User", user.Email);

            if (RememberMe )
            {
                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(2),
                    HttpOnly = true,
                    IsEssential = true
                };
                Response.Cookies.Append("UserEmail", user.Email, options);
                Response.Cookies.Append("UserId", user.Id.ToString(), options);
            }       

            // In real applications, set up authentication cookie or token here
            return RedirectToPage("/BooksPage/Index");
        }
    }
}

using CrudeoperationsonRazorPages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudeoperationsonRazorPages.Pages.Account
{
    public class SignUpModel : PageModel
    {
        private readonly MYDBContext _context;
        public SignUpModel(MYDBContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string FullName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string ConfirmPassword { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Password != ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match.");
                return Page();
            }
            var userAccount = new CrudeoperationsonRazorPages.Models.UserAccount
            {
                FullName = FullName,
                Email = Email,
                Password = Password // In real applications, hash the password before storing
            };
               _context.UserAccounts.Add(userAccount);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Account/SignIn");
        }
    }
}

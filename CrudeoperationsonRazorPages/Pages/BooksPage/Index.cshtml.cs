using CrudeoperationsonRazorPages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace CrudeoperationsonRazorPages.Pages.Books
{
    public class IndexModel : PageModel
    {
      private readonly MYDBContext _context;
        public IndexModel(MYDBContext context)
        {
            _context = context;
        }
     public IList<CrudeoperationsonRazorPages.Models.Books> BooksList { get; set; }
        public async Task<IActionResult> OnGetAsync()

        {
            var userEmail = HttpContext.Session.GetString("UserEmail")
             ?? Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToPage("/Account/SignIn"); // not logged in
            }
            BooksList = await _context.Books.ToListAsync();
            return Page();

        }
        // Handle Add Book form submission
        public async Task<IActionResult> OnPostAddBookAsync(string Title, string Description, string Author)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail")
                            ?? Request.Cookies["UserEmail"];

            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToPage("/Account/SignIn"); // not logged in
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var book = new CrudeoperationsonRazorPages.Models.Books
            {
                title = Title,
                Description = Description,
                Author = Author
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
                
    

            return RedirectToPage(); // Refresh page to show new book
        }
        // DELETE: Remove book by Id
        public async Task<IActionResult> OnPostDeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        // UPDATE: Update book details
        public async Task<IActionResult> OnPostEditBookAsync(int Id, string Title, string Description, string Author)
        {
            var book = await _context.Books.FindAsync(Id);
            if (book != null)
            {
                book.title = Title;
                book.Description = Description;
                book.Author = Author;

                _context.Books.Update(book);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}

using CrudeoperationsonRazorPages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudeoperationsonRazorPages.Pages.SearchBook
{
    public class SearchdataModel : PageModel
    {
        private readonly MYDBContext _context;
        public SearchdataModel(MYDBContext context)
        {
            _context=context;
        }
        public string searchitem { get; set; }
        public List<CrudeoperationsonRazorPages.Models.Books> itemlist { get; set; } = new();
        public void OnGet(string searchitem)
        {
            this.searchitem = searchitem;
            var allitems = _context.Books.ToList();
            if (!string.IsNullOrEmpty(searchitem))
            {
                itemlist=allitems.Where(b=>string.IsNullOrEmpty(searchitem) || b.title.ToLower().Contains(searchitem.ToLower()))
                    .ToList();
            }
            else
            {
                itemlist = allitems;
            }

        }
    }
}

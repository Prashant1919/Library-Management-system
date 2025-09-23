using Microsoft.EntityFrameworkCore;
namespace CrudeoperationsonRazorPages.DB
{
    public class MYDBContext : DbContext
    {
        public MYDBContext(DbContextOptions<MYDBContext> options) : base(options)
        {
        }
        public DbSet<CrudeoperationsonRazorPages.Models.Books> Books { get; set; }
        public DbSet<CrudeoperationsonRazorPages.Models.UserAccount> UserAccounts { get; set; }
    }
}

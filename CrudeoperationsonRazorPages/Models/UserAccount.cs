
using System.ComponentModel.DataAnnotations;

namespace CrudeoperationsonRazorPages.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

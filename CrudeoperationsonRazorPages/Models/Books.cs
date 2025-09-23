using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudeoperationsonRazorPages.Models
{
    public class Books
    {
        [Key]
       public  int id { get; set; }
        [Required]
        [DisplayName(" Book title")]
      public   string title { get; set; }
        [DisplayName(" Book description ")]
        public string Description { get; set; }
        [Required] 
       public  string Author { get;set; }
    }
}

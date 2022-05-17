using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryReact.Models
{
    public class Publishers
    {   
        [Key]
        
        [Required(ErrorMessage = " Enter Publisher ID")]
        public string PublisherID { get; set; }

        [Required(ErrorMessage = " Enter Publisher Name")]
        public string PublisherName { get; set; }



    }
}

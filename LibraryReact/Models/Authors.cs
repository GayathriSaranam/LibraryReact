using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryReact.Models
{
    public class Authors
    {
        [Key]
        [Required(ErrorMessage = " Enter Author ID")]
        public string AuthorID { get; set; }

      


        [Required(ErrorMessage = " Enter Author Name")]
        public string AuthorName { get; set; }


       

    }
}

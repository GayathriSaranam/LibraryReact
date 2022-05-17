using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryReact.Models
{
    public class Books
    {

        [Key]
        [Required(ErrorMessage = " Enter Book ID")]
        public string BookID { get; set; }

        [Required(ErrorMessage = " Enter Book Name")]
        public string BookName { get; set; }

        [Required(ErrorMessage = " Enter Author ID")]

        public string AuthorID { get; set; }



        [Required(ErrorMessage = " Enter Publisher ID")]
        public string PublisherID { get; set; }


        [Required(ErrorMessage = " Enter Language")]
        public string BooKLanguage { get; set; }

        [Required(ErrorMessage = " Enter Book Cost")]
        public string BookCost { get; set; }

        



    }
}

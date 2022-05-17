using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryReact.Models
{
    public class IssueBooks
    {
        [Key]
        public int IssueBookId { get; set; }

        
        [Required(ErrorMessage = " Enter Member ID")]
        public string MemberID { get; set; }

        [Required(ErrorMessage = " Enter Member Name")]
        public string MemberFullName { get; set; }

        [Required(ErrorMessage = " Enter Book ID")]
        public string BookID { get; set; }

        [Required(ErrorMessage = " Enter Book Name")]
        public string BookName { get; set; }

        [Required(ErrorMessage = " Enter Issue Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BookIssueDate { get; set; }

        [Required(ErrorMessage = " Enter Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BookDueDate { get; set; }

        
        
       

    }
}

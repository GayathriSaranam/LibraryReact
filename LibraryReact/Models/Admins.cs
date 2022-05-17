using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace LibraryReact.Models
{

    public class Admins
    {
        [Key]
        [Required(ErrorMessage = "Please enter User Name")]
        public string AdminID { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string AdminPassword { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string AdminFullName { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryReact.Models
{
    public class Members
    {

        [Key]
        [Required(ErrorMessage = " Enter Member ID")]
        public string MemberID { get; set; }

        public string MemberFullName { get; set; }


        public DateTime MemberDOB { get; set; }

        public string MemberContactNo { get; set; }


        public string MemberEmail { get; set; }

        public string MemberFullAddress { get; set; }


        [Required(ErrorMessage = "Password is required")]
        public string MemberPassword { get; set; }

    }
}

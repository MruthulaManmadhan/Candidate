using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate.Models
{
    public class UserInfo
    {
        public int UserID { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }

        [Required(ErrorMessage = "Email ID is required")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Display(Name = "Current Password")]
        //[DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        //[Display(Name = "New Password")]
        //[DataType(DataType.Password)]
        public string NewPassword { get; set; }

        //[Display(Name = "Confirm Password")]
        //[Compare("NewPassword",ErrorMessage = "Doesn't match with New password")]
        //[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}

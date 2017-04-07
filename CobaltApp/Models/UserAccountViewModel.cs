using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CobaltApp.Models
{
    public class UserAccountViewModel
    {
       // [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Login:")]
        [Required(ErrorMessage = "You must input login!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must input password!")]
        [StringLength(100, ErrorMessage = "The password must contain {2} or more symbols.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string HashOfPassword { get; set; }
    }
}
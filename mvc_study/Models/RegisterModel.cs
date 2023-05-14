using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc_study.Models
{
    public class RegisterModel
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        [Compare("password",ErrorMessage = "Password Must Be Same")]
        public string confirmPassword { get; set; }
    }
}
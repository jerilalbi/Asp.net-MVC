﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc_study.Models
{
    public class LoginModel
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
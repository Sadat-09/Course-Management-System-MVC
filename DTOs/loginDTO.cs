﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.DTOs
{
    public class loginDTO
    {
       
        public string username { get; set; }

        [Required]
        /*[StringLength(100, MinimumLength = 4, ErrorMessage = "Password must be at least 4 characters long")]
        [DataType(DataType.Password)]*/
        /* [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$", ErrorMessage = "Password must be at least 6 characters long and contain both letters and numbers")]*/
        public string password { get; set; }
    }
}
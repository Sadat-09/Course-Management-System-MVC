using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.DTOs
{
    public class userDTO
    {
        public int id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters")]
        public string username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Password must be at least 6 characters long")]
        
        public string password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters")]
        public string email { get; set; }

        [Required(ErrorMessage = "Type is required")]
        [StringLength(20, ErrorMessage = "Type cannot be longer than 20 characters")]
        public string Type { get; set; }
    }
}

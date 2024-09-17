using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.DTOs
{
    public class courseDTO
    {

        public int id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "course must be at least 4 characters long")]
        public string cname { get; set; }
        [Required]
       
        public string duration { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be at least 3     characters long")]
        public string instructor { get; set; }
        
    }
}
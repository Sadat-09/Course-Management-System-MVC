using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.DTOs
{
    public class enrollmentDTO
    {
        public int id { get; set; }
        public Nullable<int> uid { get; set; }
        public Nullable<int> cid { get; set; }
    }
}
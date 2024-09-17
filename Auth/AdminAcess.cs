using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exam.EF;

namespace Exam.Auth
{
    public class AdminAcess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (user)httpContext.Session["user"];
            if (user != null && user.Type.Equals("admin"))
            {
                return true;
            }
            return false;
        }
    }
}
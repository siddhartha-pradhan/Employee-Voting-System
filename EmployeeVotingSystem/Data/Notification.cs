using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace EmployeeVotingSystem.Data
{
    public class Notification
    {
        public void ShowToastrMessage(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), 
                "toastr_message", String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }
    }
}
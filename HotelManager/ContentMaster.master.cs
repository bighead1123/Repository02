using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ContentMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void lnkbtn_Click(object sender, EventArgs e)
    {
         System.Web.UI.Page page = new Page();
        Server.Execute("Logout.aspx");
        if (string.IsNullOrEmpty(page.User.Identity.Name))
            Server.Execute("Logout.aspx");
        else
            Response.Redirect("Login.aspx");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntLibStudy.WEB
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Helper.BasePage basePage = (Helper.BasePage)this.Page;
            if (basePage!=null)
            {
                if (basePage.IsLogin)
                {
                    lblName.Text = basePage.UserName;
                    divLogin.Visible = false;
                    divLogout.Visible = true;
                }
                else
                {
                    divLogin.Visible = true;
                    divLogout.Visible = false;
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Helper.Utils.ClearCookie();
            Response.Redirect("~/Default.aspx");
        }
    }
}

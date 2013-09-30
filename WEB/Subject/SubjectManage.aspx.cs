using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntLibStudy.WEB.Subject
{
    public partial class SubjectManage : Helper.BasePage
    {
        protected override void ShowPage()
        {
            base.ShowPage();
        }

        protected void btnAddSubject_Click(object sender, EventArgs e)
        {
            if (!this.IsLogin)
            {
                Helper.Utils.MessageBox(this, "您还未登录,请先登录!", "~/Login.aspx?returnUrl=" + Request.RawUrl);
            }
            else if (!this.IsAdmin)
            {
                Helper.Utils.MessageBox(this, "您不是管理员无法添加科目");
            }
            else
            {
                Response.RedirectToRoute("SubjectRoute", new
                {
                    id = 0
                });
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntLibStudy.WEB.Student
{
    public partial class StudentManage : Helper.BasePage
    {
        protected override void ShowPage()
        {
            base.ShowPage();
        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (!this.IsLogin)
            {
                Helper.Utils.MessageBox(this, "您还未登录,请先登录!", "~/Login.aspx?returnUrl=" + Request.RawUrl);
            }
            else if (!this.IsAdmin)
            {
                Helper.Utils.MessageBox(this, "您不是管理员无法添加学员");
            }
            else
            {
                Response.RedirectToRoute("StudentRoute", new
                {
                    id = 0
                });
            }
        }
    }
}
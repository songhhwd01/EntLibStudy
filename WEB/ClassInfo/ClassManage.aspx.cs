using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntLibStudy.Model;
using EntLibStudy.BLL;

namespace EntLibStudy.WEB.ClassInfo
{
    public partial class ClassManage : Helper.BasePage
    {
        protected override void ShowPage()
        {
            base.ShowPage();
        }


        protected void btnAddClass_Click(object sender, EventArgs e)
        {
            if (!this.IsLogin)
            {
                Helper.Utils.MessageBox(this, "您还未登录,请先登录!", "~/Login.aspx?returnUrl=" + Request.RawUrl);
            }
            else if (!this.IsAdmin)
            {
                Helper.Utils.MessageBox(this, "您不是管理员无法添加班级");
            }
            else
            {
                Response.RedirectToRoute("ClassRoute", new
                {
                    id = 0
                });
            }

        }
    }
}
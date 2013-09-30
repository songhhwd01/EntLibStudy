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
    public partial class ClassView : Helper.BasePage
    {
        protected override void ShowPage()
        {
            base.ShowPage();
            if (RouteData.Route == null)
            {
                this.RedirectPermanent("~/Default.aspx");
            }
            if (RouteData.Values.Count == 0)
            {
                this.RedirectPermanent("~/Default.aspx");
            }
            if (!IsPostBack)
            {
                int classId = 0;
                if (RouteData.Values["id"] != null)
                {
                    if (int.TryParse(RouteData.Values["id"].ToString(), out classId))
                    {
                        BindClassInfo(classId);
                    }
                    else
                    {
                        this.RedirectPermanent("~/Default.aspx");
                    }
                }
                else
                {
                    this.RedirectPermanent("~/Default.aspx");
                }
            }
        }

        private void BindClassInfo(int classId)
        {
            if (classId == 0)
            {
                this.ViewState["classid"] = classId;
            }
            else
            {
                ClassInfoManage classInfoBll = new ClassInfoManage();
                EntLibStudy.Model.ClassInfo classInfo = new Model.ClassInfo();
                classInfo = classInfoBll.SelectById(classId);
                txtClassName.Text = classInfo.Name;
                this.ViewState["classId"] = classInfo.Id;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ClassInfoManage classInfoBll = new ClassInfoManage();
            try
            {
                int classId = Convert.ToInt32(this.ViewState["classId"]);
                if (classId == 0)
                {
                    int id = classInfoBll.Add(new Model.ClassInfo()
                    {
                        Name = txtClassName.Text.Trim()
                    });
                    Helper.Utils.MessageBox(this, "新增班级信息成功!", this.GetRouteUrl("ClassRoute", new
                    {
                        id = id
                    }));
                }
                else
                {
                    EntLibStudy.Model.ClassInfo classInfo = new Model.ClassInfo();
                    classInfo = classInfoBll.SelectById(classId);
                    classInfo.Name = txtClassName.Text.Trim();
                    classInfoBll.Update(classInfo);
                    Helper.Utils.MessageBox(this, "编辑班级信息成功!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntLibStudy.WEB.Subject
{
    public partial class SubjectView : Helper.BasePage
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
                int subjectId = 0;
                if (RouteData.Values["id"] != null)
                {
                    if (int.TryParse(RouteData.Values["id"].ToString(), out subjectId))
                    {
                        BindSubjectInfo(subjectId);
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

        private void BindSubjectInfo(int subjectId)
        {
            if (subjectId == 0)
            {
                this.ViewState["subjectId"] = subjectId;
            }
            else
            {
                BLL.SubjectManage subjectBll = new BLL.SubjectManage();
                EntLibStudy.Model.Subject subjectInfo = new Model.Subject();
                subjectInfo = subjectBll.SelectById(subjectId);
                txtName.Text = subjectInfo.Name;
                txtScore.Text = subjectInfo.Score.ToString();
                this.ViewState["subjectId"] = subjectInfo.Id;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL.SubjectManage subjectBll = new BLL.SubjectManage();
            try
            {
                int studentId = Convert.ToInt32(this.ViewState["studentId"]);
                if (studentId == 0)
                {
                    int id = subjectBll.Add(new Model.Subject()
                    {
                        Name = txtName.Text.Trim(),
                        Score = Double.Parse(txtScore.Text.Trim())
                    });
                    Helper.Utils.MessageBox(this, "新增科目信息成功!", this.GetRouteUrl("SubjectRoute", new
                    {
                        id = id
                    }));
                }
                else
                {
                    EntLibStudy.Model.Subject subjectInfo = new Model.Subject();
                    subjectInfo = subjectBll.SelectById(studentId);
                    subjectInfo.Name = txtName.Text.Trim();
                    subjectInfo.Score = Double.Parse(txtScore.Text.Trim());
                    subjectBll.Update(subjectInfo);
                    Helper.Utils.MessageBox(this, "编辑科目信息成功!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
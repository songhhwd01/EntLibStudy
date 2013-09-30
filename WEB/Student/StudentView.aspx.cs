using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntLibStudy.Model;
using EntLibStudy.BLL;

using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;

namespace EntLibStudy.WEB.Student
{
    public partial class StudentView : Helper.BasePage
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
                int studentId = 0;
                if (RouteData.Values["id"] != null)
                {
                    if (int.TryParse(RouteData.Values["id"].ToString(), out studentId))
                    {
                        BindStudentInfo(studentId);
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

        private void BindStudentInfo(int studentId)
        {
            if (studentId == 0)
            {
                this.ViewState["studentId"] = studentId;
            }
            else
            {
                IBLL.IStudentManage studentBll = PolicyInjection.Create<BLL.StudentManage, IBLL.IStudentManage>();
                EntLibStudy.Model.Student studentInfo = new Model.Student();
                studentInfo = studentBll.SelectById(studentId);
                txtSid.Text = studentInfo.Sid;
                txtPwd.Text = studentInfo.Password;
                txtName.Text = studentInfo.Name;
                rblSex.SelectedValue = studentInfo.Sex.ToString();
                txtBirthday.Text = studentInfo.Birthday.ToString();
                this.ViewState["studentId"] = studentInfo.Id;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (!IsValid)
            //{
            //    return;
            //}
            IBLL.IStudentManage studentBll = PolicyInjection.Create<BLL.StudentManage, IBLL.IStudentManage>();
            Model.Student student = null;
            try
            {
                int studentId = Convert.ToInt32(this.ViewState["studentId"]);
                if (studentId == 0)
                {
                    if (GetValidatedStudent(ref student))
                    {
                        int id = studentBll.Add(student);
                        Helper.Utils.MessageBox(this, "新增学员信息成功!", this.GetRouteUrl("StudentRoute", new
                        {
                            id = id
                        }));
                    }
                    else
                        Helper.Utils.MessageBox(this, student.ValidateTag);
                }
                else
                {
                    student = studentBll.SelectById(studentId);
                    if (GetValidatedStudent(ref student))
                    {
                        studentBll.Update(student);
                        Helper.Utils.MessageBox(this, "编辑学员信息成功!");
                    }
                    else
                        Helper.Utils.MessageBox(this, student.ValidateTag);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取已验证的学员对象
        /// </summary>
        /// <param name="student">学员对象</param>
        /// <returns>是否验证成功</returns>
        private bool GetValidatedStudent(ref Model.Student student)
        {
            if (student == null)
            {
                student = new Model.Student();
            }
            student.ClassId = Convert.ToInt32(ddlClass.SelectedValue);
            student.Sid = txtSid.Text.Trim();
            student.Password = Helper.Utils.CreateHash("CustomHashCryptography", txtPwd.Text.Trim());
            student.Name = txtName.Text.Trim();
            student.Sex = Convert.ToInt32(rblSex.SelectedValue);
            student.Birthday = DateTime.Parse(txtBirthday.Text.Trim());

            return student.IsValid();
        }
    }
}
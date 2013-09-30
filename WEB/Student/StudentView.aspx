<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="StudentView.aspx.cs" Inherits="EntLibStudy.WEB.Student.StudentView" %>

<%@ Register Assembly="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet"
    Namespace="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet"
    TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <div style="text-align: right;">
            <asp:HyperLink ID="HyperLink1" NavigateUrl='<%$ RouteUrl:RouteName=StudentManageRoute %>'
                runat="server" Text="返回学员列表" /></div>
        <table cellpadding="0" cellspacing="0" border="0" width="70%" align="center">
            <tr>
                <td align="right">
                    班级:
                </td>
                <td>
                    <asp:DropDownList ID="ddlClass" runat="server" 
                        DataTextField="Name" DataValueField="Id" DataSourceID="ObjectDataSource1">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        SelectMethod="SelectAll" TypeName="EntLibStudy.BLL.ClassInfoManage">
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td align="right">
                    登录ID:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSid" />
                    <cc1:PropertyProxyValidator ID="PropertyProxyValidator1" runat="server" 
                        ControlToValidate="txtSid" PropertyName="Sid"
                        SourceTypeName="EntLibStudy.Model.Student,EntlibStudy.Model" ValidationGroup="test"></cc1:PropertyProxyValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    密码:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPwd" TextMode="Password" />
                    <cc1:PropertyProxyValidator ID="PropertyProxyValidator2" runat="server" 
                        ControlToValidate="txtPwd" PropertyName="Password"
                        SourceTypeName="EntLibStudy.Model.Student,EntlibStudy.Model" ValidationGroup="test"></cc1:PropertyProxyValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    姓名:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtName" />
                    <cc1:PropertyProxyValidator ID="PropertyProxyValidator3" runat="server" 
                        ControlToValidate="txtName" PropertyName="Name"
                        SourceTypeName="EntLibStudy.Model.Student,EntlibStudy.Model" ValidationGroup="test"></cc1:PropertyProxyValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    性别:
                </td>
                <td align="left">
                    <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="男" Value="1" Selected="True" />
                        <asp:ListItem Text="女" Value="0" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    生日:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtBirthday" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button Text="提交" ID="btnSubmit" runat="server" ValidationGroup="test" onclick="btnSubmit_Click"/>
                </td>
            </tr>
        </table>
    </p>
</asp:Content>

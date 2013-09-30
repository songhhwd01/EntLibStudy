<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubjectView.aspx.cs" Inherits="EntLibStudy.WEB.Subject.SubjectView" %>
<%@ Register Assembly="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet"
    Namespace="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<p>
        <div style="text-align: right;">
            <asp:HyperLink ID="HyperLink1" NavigateUrl='<%$ RouteUrl:RouteName=SubjectManageRoute %>'
                runat="server" Text="返回科目列表" /></div>
        <table cellpadding="0" cellspacing="0" border="0" width="50%" align="center">
            <tr>
                <td align="right">
                    科目名称:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtName" />
                    <cc1:PropertyProxyValidator ID="PropertyProxyValidator1" runat="server" 
                        ControlToValidate="txtName" PropertyName="Name"
                        SourceTypeName="EntLibStudy.Model.Subject,EntlibStudy.Model"></cc1:PropertyProxyValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    学分:
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ID="txtScore" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtScore"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button Text="提交" ID="btnSubmit" runat="server" onclick="btnSubmit_Click"/>
                </td>
            </tr>
        </table>
    </p>
</asp:Content>

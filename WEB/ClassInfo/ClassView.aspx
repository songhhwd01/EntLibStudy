<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ClassView.aspx.cs" Inherits="EntLibStudy.WEB.ClassInfo.ClassView" %>
    
<%@ Register Assembly="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet"
    Namespace="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <div style="text-align: right;">
            <asp:HyperLink NavigateUrl='<%$ RouteUrl:RouteName=ClassManageRoute %>' runat="server"
                Text="返回班级列表" /></div>
        <table cellpadding="0" cellspacing="0" border="0" width="50%" align="center">
            <tr>
                <td align="right">
                    班级名称:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtClassName" />
                    <cc1:PropertyProxyValidator ID="PropertyProxyValidator1" runat="server" 
                        ControlToValidate="txtClassName" PropertyName="Name"
                        SourceTypeName="EntLibStudy.Model.ClassInfo,EntlibStudy.Model"></cc1:PropertyProxyValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button Text="提交" ID="btnSubmit" runat="server" onclick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </p>
</asp:Content>

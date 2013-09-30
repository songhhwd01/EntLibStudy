<%@ Page Title="登录" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="EntLibStudy.WEB.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" align="center" width="30%">
        <tr>
            <td colspan="2">
                <asp:Literal Text="" runat="server" ID="ltMsg" />
            </td>
        </tr>
        <tr>
            <td>
                用户名
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtUid" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" ErrorMessage="*" ControlToValidate="txtUid"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td>
                密码
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtPwd" TextMode="Password" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                    runat="server" ErrorMessage="*" ControlToValidate="txtPwd"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button Text="登陆" runat="server" ID="btnLogin" OnClick="btnLogin_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

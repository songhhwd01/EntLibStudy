<%@ Page Title="学员管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentManage.aspx.cs" Inherits="EntLibStudy.WEB.Student.StudentManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:right;">
        <asp:Button Text="添加学员" runat="server" ID="btnAddStudent" 
            onclick="btnAddStudent_Click"  />
    </div>
    <div style="text-align:center;">
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" Width="40%" HorizontalAlign="Center" 
            AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="ClassId" HeaderText="ClassId" 
                    SortExpression="ClassId" />
                <asp:BoundField DataField="Sid" HeaderText="Sid" SortExpression="Sid" />
                <asp:BoundField DataField="Password" HeaderText="Password" 
                    SortExpression="Password" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex" />
                <asp:BoundField DataField="Birthday" HeaderText="Birthday" 
                    SortExpression="Birthday" />
                <asp:BoundField DataField="IsAdmin" HeaderText="IsAdmin" 
                    SortExpression="IsAdmin" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="<%# this.GetRouteUrl("StudentRoute",new {id=Eval("id")}) %>">编辑</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="SelectAll" TypeName="EntLibStudy.BLL.StudentManage">
        </asp:ObjectDataSource>
    </div>
</asp:Content>

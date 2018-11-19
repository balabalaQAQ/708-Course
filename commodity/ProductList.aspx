<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h4>商品列表</h4>
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>


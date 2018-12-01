<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h4>商品列表</h4>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" PageSize="18">
    <Columns>
        <asp:BoundField DataField="SN" HeaderText="商品编号" />
        <asp:BoundField DataField="Name" HeaderText="商品名字" />
        <asp:BoundField DataField="DSCN" HeaderText="说明" />
        <asp:BoundField DataField="Catagory" HeaderText="商品类别" />
        <asp:CommandField EditText="修改" HeaderText="操作" InsertText="添加" ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
    </Columns>
    <RowStyle HorizontalAlign="Center" Width="150px" />
    </asp:GridView>
</asp:Content>

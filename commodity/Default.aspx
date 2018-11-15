<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <h4>商品列表</h4>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px">
        </asp:DropDownList>
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing">
         <Columns>
             <asp:BoundField DataField="SN" HeaderText="商品编号">
             <ItemStyle Width="150px" />
             </asp:BoundField>
             <asp:BoundField DataField="Name" HeaderText="商品名称">
             <ItemStyle Width="150px" />
             </asp:BoundField>
             <asp:BoundField DataField="DSCN" HeaderText="说明">
             <ItemStyle Width="200px" />
             </asp:BoundField>
             <asp:CommandField HeaderText="操作" ShowDeleteButton="True" ShowEditButton="True">
             <ItemStyle Width="150px" />
             </asp:CommandField>
         </Columns>
        </asp:GridView>
     </asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Information.aspx.cs" Inherits="Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table>
<tr>
<td>
Country
</td>
<td>
    <asp:DropDownList ID="ddl_country" runat="server" DataTextField="country" 
        DataValueField="intglcode" AutoPostBack="true" 
        onselectedindexchanged="ddl_country_SelectedIndexChanged">
    </asp:DropDownList>
</td>
</tr>
<tr>
<td>
State
</td>
<td>
    <asp:DropDownList ID="ddl_state" runat="server" DataTextField="state" 
        DataValueField="intglcode" AutoPostBack="true" 
        onselectedindexchanged="ddl_state_SelectedIndexChanged">
    </asp:DropDownList>
</td>
</tr>
<tr>
<td>
City
</td>
<td>
    <asp:DropDownList ID="ddl_city" runat="server" DataTextField="city" DataValueField="intglcode" AutoPostBack="true">
    </asp:DropDownList>
</td>
</tr>
<tr>
<td>
    <asp:Button ID="btn_submit" runat="server" Text="Submit" 
        onclick="btn_submit_Click"/>
    <asp:Button ID="Button1" runat="server" Text="Update" onclick="Button1_Click" />
</td>
</tr>
<tr>
<td>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
        AllowPaging="true" DataKeyNames="code" PageSize="5" 
        onrowediting="GridView1_RowEditing" onrowdeleting="GridView1_RowDeleting">
    <Columns>
    <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ButtonType="Button"/>
    <asp:CommandField HeaderText="Edit" ShowEditButton="true" ButtonType="Button" />  
    <asp:BoundField HeaderText="Country_id" DataField="country_id"/>
    <asp:BoundField HeaderText="State_id" DataField="state_id" />
    <asp:BoundField HeaderText="City_id" DataField="city_id" />
    </Columns>
    </asp:GridView>
</td>
</tr>
</table>
</asp:Content>


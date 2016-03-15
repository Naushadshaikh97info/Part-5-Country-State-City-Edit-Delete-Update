<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Country.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tr>
            <td>
                Country
            </td>
            <td>
                <asp:TextBox ID="txt_country" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btn_submit" runat="server" Text="Submit" 
                    onclick="btn_submit_Click" />
                <asp:Button ID="btn_updateS" runat="server" Text="Update" 
                    onclick="btn_update_Click" />
            </td>
        </tr>
        <tr>
        <td colspan="2">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="false"  
                AllowPaging="true" PageSize ="5" DataKeyNames="code" 
                onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing">
            <Columns>
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ButtonType="Button" />
            <asp:CommandField HeaderText="Edit" ShowEditButton="true" ButtonType="Button" />
            <asp:BoundField HeaderText="Country" DataField="country"/> 
            </Columns> 
            </asp:GridView>
        </td>
        </tr>
    </table>
</asp:Content>

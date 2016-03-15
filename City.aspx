<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="City.aspx.cs" Inherits="City" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table>
        <tr>
            <td>
                State
            </td>
            <td>
                <asp:DropDownList ID="ddl_State" runat="server" DataTextField="state" DataValueField="intglcode"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                City
            </td>
            <td>
                <asp:TextBox ID="txt_city" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
                <asp:Button ID="btn_update" runat="server" Text="Update" 
                    onclick="btn_update_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                    PageSize="5" DataKeyNames="code" onrowdeleting="GridView1_RowDeleting" 
                    onrowediting="GridView1_RowEditing">
                    <Columns>
                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ButtonType="Button" />
                    <asp:CommandField HeaderText="Edit" ShowEditButton="true" ButtonType="Button" />
                        <asp:BoundField HeaderText="State_id" DataField="state_id" />
                        <asp:BoundField HeaderText="City" DataField="city" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

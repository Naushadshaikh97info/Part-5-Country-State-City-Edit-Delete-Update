<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="State.aspx.cs" Inherits="Statet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table>
        <tr>
            <td>
                Country
            </td>
            <td>
                <asp:DropDownList ID="ddl_country" runat="server" DataTextField="country" DataValueField="intglcode"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                State
            </td>
            <td>
                <asp:TextBox ID="txt_state" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn_submit" runat="server" Text="Submit" onclick="Button1_Click" 
                    Width="61px" />
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
                        <asp:BoundField HeaderText="Country_id" DataField="country_id" />
                        <asp:BoundField HeaderText="State" DataField="state" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

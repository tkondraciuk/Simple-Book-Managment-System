<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserDetails.aspx.cs" Inherits="UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <div class="bigTitle">Szczegóły użytkownika</div>
    <div class="formAdd">
        <div>Imię: <asp:Label ID="imie" runat="server" Text="Label"></asp:Label></div>
        <div>Nazwisko: <asp:Label ID="nazwisko" runat="server" Text="Label"></asp:Label></div>
        <div>E-mail: <asp:Label ID="email" runat="server" Text="Label"></asp:Label></div>
        <asp:Button ID="Button1" runat="server" CssClass="submit" Text="Zatwierdź" OnClick="Button1_Click"/>
    </div>
    <div class="grid2">
        <asp:GridView ID="GridView1" runat="server" CssClass="myGridview" RowStyle-CssClass="rows" HeaderStyle-CssClass="gridHeader" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Image" ImageUrl="~/ZwrocButton.png" Text="Zwróć"/>
            </Columns>
        <HeaderStyle CssClass="gridHeader"></HeaderStyle>

        <RowStyle CssClass="rows"></RowStyle>
        </asp:GridView>
    </div>
</asp:Content>
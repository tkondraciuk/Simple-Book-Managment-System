<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LendBook.aspx.cs" Inherits="LendBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <div class="bigTitle">Wypożycz Książkę</div>
    <div class="formAdd">
        <div>E-mail: <asp:TextBox ID="email" runat="server" CssClass="textbox"></asp:TextBox></div>
        <asp:Button ID="Button1" runat="server" CssClass="submit" Text="Zatwierdź" OnClick="Button1_Click"  />
    </div>
</asp:Content>


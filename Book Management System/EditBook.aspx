<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditBook.aspx.cs" Inherits="EditBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <div class="bigTitle">Edytuj książkę</div>
    <div class="formAdd">
        <div>Tytuł: <asp:TextBox ID="tytul" runat="server" CssClass="textbox"></asp:TextBox></div>
        <div>Autor: <asp:TextBox ID="autor" runat="server" CssClass="textbox"></asp:TextBox></div>
        <div>Cykl: <asp:TextBox ID="cykl" runat="server" CssClass="textbox"></asp:TextBox></div>
        <div>Gatunek: <asp:DropDownList ID="gatunek" runat="server" CssClass="dropdownlist">
            <asp:ListItem>---</asp:ListItem>
            <asp:listitem>autobiografia/pamiętnik</asp:listitem>
            <asp:listitem>biografia</asp:listitem>
            <asp:listitem>fantasy</asp:listitem>
            <asp:listitem>literatura piękna/historyczne</asp:listitem>
            <asp:listitem>literatura piękna/klasyka</asp:listitem>
            <asp:listitem>literatura współczesna</asp:listitem>
            <asp:listitem>science fiction</asp:listitem>
            <asp:listitem>publicystyka literacka/esej</asp:listitem>
            <asp:listitem>thriller/sensacja/kryminał</asp:listitem>
        </asp:DropDownList></div>
        <div>Ilość: <asp:textbox ID="ilosc" runat="server" CssClass="textbox"></asp:textbox></div>
        <asp:Button ID="Button1" runat="server" CssClass="submit" Text="Zatwierdź" OnClick="Button1_Click"/>
    </div>
    
</asp:Content>


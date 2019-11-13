<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BooksReview.aspx.cs" Inherits="BooksReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Książki
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server" >
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">

    <div class="search">
        <asp:Label ID="Label1" runat="server" Text="Szukaj:"></asp:Label>
        <div><asp:TextBox ID="szukaj" runat="server" CssClass="textbox" OnTextChanged="szukaj_TextChanged" AutoPostBack="true" ></asp:TextBox></div>
    </div>
    <div class="grid">
        <asp:GridView ID="GridView1" runat="server" CssClass="myGridview" RowStyle-CssClass="rows" HeaderStyle-CssClass="gridHeader" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowCommand="GridView1_RowCommand" >
            <Columns>
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/deleteButtonImg.jpg" ShowDeleteButton="True" />
                <asp:CommandField ShowEditButton="True" ButtonType="Image" EditImageUrl="~/editButtonImg.png" />
                <asp:ButtonField ButtonType="Image" ImageUrl="~/WypozyczButton.png" Text="Wypożycz" CommandName="Wypożycz"/>
            </Columns>

    <HeaderStyle CssClass="gridHeader"></HeaderStyle>

    <RowStyle CssClass="rows"></RowStyle>
        </asp:GridView>
    </div>
    
</asp:Content>


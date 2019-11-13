using MongoConnector;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditBook : System.Web.UI.Page
{
    string connenctionString = @"mongodb://localhost:27017";
    IMongoClient client;
    IMongoDatabase db;
    IMongoCollection<Book> booksCollection;
    Book book;
    protected void Page_Load(object sender, EventArgs e)
    {
        booksCollection = Utils.mongoConnection.BookCollection;
            book = Session["book"] as Book;
        if (!IsPostBack)
        {
            tytul.Text = book.Title;
            autor.Text = book.Author;
            gatunek.SelectedValue = book.Gentle;
            cykl.Text = book.Series;
            ilosc.Text = book.TotalNumber.ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        book.Author = autor.Text;
        book.Title = tytul.Text;
        book.Gentle = gatunek.SelectedValue;
        book.Series = cykl.Text;
        book.TotalNumber = Convert.ToInt32(ilosc.Text);
        booksCollection.ReplaceOne(b => b.Id == book.Id, book);
           
        Server.Transfer("BooksReview.aspx");
    }


    protected void tytul_TextChanged(object sender, EventArgs e)
    {
        TextBox textbox = sender as TextBox;
        
        
    }
}
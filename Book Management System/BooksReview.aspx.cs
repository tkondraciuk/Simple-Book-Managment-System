using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoConnector;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;

public partial class BooksReview : System.Web.UI.Page
{
    private string[] columnNames = { "Autor", "Tytuł", "Cykl", "Gatunek", "Dostępne" };
    private string connenctionString = @"mongodb://localhost:27017";
    private IMongoClient client;
    private IMongoDatabase db;
    private IMongoCollection<Book> booksCollection;
    private GridViewAdapter gridView;

    protected void Page_Load(object sender, EventArgs e)
    {
        booksCollection = Utils.mongoConnection.BookCollection;
        gridView = new GridViewAdapter(GridView1, columnNames);
        var allBooks = booksCollection.LoadEntitiesFromDatabase<Book>();
        gridView.AddMany(allBooks);
    }
    
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var id = e.Values["Id"].ToString();
        var a = booksCollection.DeleteOne(b=>b.Id.Equals(id));
        Server.Transfer("BooksReview.aspx");
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string id = GridView1.getCellContent(e.NewEditIndex, 3);
        Session["book"] = booksCollection.Find(b=>b.Id.Equals(id)).First();
        Server.Transfer("EditBook.aspx");
    }

    protected void szukaj_TextChanged(object sender, EventArgs e)
    {
        string fraza = szukaj.Text.ToLower();
        List<Book> books = booksCollection.Find(b => b.Author.ToLower().Contains(fraza) 
            || b.Title.ToLower().Contains(fraza) 
            || b.Series.ToLower().Contains(fraza) 
            || b.Gentle.ToLower().Contains(fraza)).ToList();

        ReloadGridView(books);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Wypożycz")
        {
            int rowNumber = e.GetRowNumber();
            string id = GridView1.getCellContent(rowNumber, 3);
            Session["book"] = booksCollection.Find(b => b.Id.Equals(id)).First();
            Server.Transfer("LendBook.aspx");
        }
    }

    private void ReloadGridView(IEnumerable<Book> users)
    {
        gridView.Table.Clear();
        gridView.AddMany(users);
    }
}
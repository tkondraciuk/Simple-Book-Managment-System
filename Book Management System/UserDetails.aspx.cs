using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoConnector;
using MongoDB.Driver;

public partial class UserDetails : Page
{
    string[] columnNames = {"Autor", "Tytuł" };
    User user;
    MongoClient client;
    IMongoDatabase db;
    IMongoCollection<Book> booksCollection;
    IMongoCollection<User> usersCollection;
    GridViewAdapter gridview;
    protected void Page_Load(object sender, EventArgs e)
    {
        booksCollection = Utils.mongoConnection.BookCollection;
        usersCollection = Utils.mongoConnection.UserCollection;
        gridview = new GridViewAdapter(GridView1, columnNames);
        user = Session["user"] as User;
        imie.Text = user.Firstname;
        nazwisko.Text = user.Lastname;
        email.Text = user.Email;
        List<Book> books = booksCollection.Find(b => user.RentedBooksIds.Contains(b.Id)).ToList();
        gridview.AddMany(books);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
        Book book = booksCollection.Find(b => b.Id.Equals(id)).First();
        user.RentedBooksIds.Remove(book.Id);
        book.AvailableNumber++;
        booksCollection.ReplaceOne(b => b.Id.Equals(book.Id), book);
        usersCollection.ReplaceOne(u => u.Id.Equals(user.Id), user);
        Server.Transfer("UserDetails.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Server.Transfer("UsersReview.aspx");
    }
}
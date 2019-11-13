using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoConnector;
using MongoDB.Driver;
using MongoDB.Bson;

public partial class LendBook : Page
{
    Book book;
    IMongoClient client;
    IMongoDatabase db;
    IMongoCollection<Book> booksCollection;
    IMongoCollection<User> usersCollection;

    protected void Page_Load(object sender, EventArgs e)
    {
        booksCollection = Utils.mongoConnection.BookCollection;
        usersCollection = Utils.mongoConnection.UserCollection;
        book = Session["book"] as Book;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string email = this.email.Text;
        User user = usersCollection.Find(u => u.Email == email).First();
        user.RentedBooksIds.Add(book.Id);
        book.AvailableNumber--;
        usersCollection.ReplaceOne(u => u.Id == user.Id, user);
        booksCollection.ReplaceOne(b => b.Id == book.Id, book);
        Server.Transfer("BooksReview.aspx");
    }
 
}
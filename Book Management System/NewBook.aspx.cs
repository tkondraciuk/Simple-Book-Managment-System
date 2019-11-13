using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoConnector;
using MongoDB.Driver;
using MongoDB.Bson;

public partial class NewBook : Page
{
    MongoClient client;
    IMongoDatabase db;
    IMongoCollection<Book> booksCollection;
    BsonDocument[] lastIdPipeline =
    {
        new BsonDocument
        {
            {"$group",new BsonDocument
            {
                {"_id","null" },
                {"lastId",new BsonDocument
                {
                    {"$max","$_id" }
                } }
            } }
        }
    };
   
    
    protected void Page_Load(object sender, EventArgs e)
    {
        booksCollection = Utils.mongoConnection.BookCollection;
        setLastId();
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        string author = autor.Text;
        string title = tytul.Text;
        string series = cykl.Text;
        string genhre = gatunek.Text;
        int totalNumber = Convert.ToInt32(ilosc.Text);



        Book newBook = new Book(author, title, series, genhre, totalNumber);
        booksCollection.InsertOne(newBook);
        Server.Transfer("BooksReview.aspx");
    }
    private void setLastId()
    {
        var lastId = 0;
        if (booksCollection.isNotEmpty())
            lastId = booksCollection.Aggregate<BsonDocument>(lastIdPipeline).First()["lastId"].AsInt32;
        Book.setLastId(lastId);
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoConnector;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;

public partial class NewUser : Page
{
    MongoClient client;
    IMongoCollection<User> usersCollection;
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
        usersCollection = Utils.mongoConnection.UserCollection;
        setLastId();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string firstName = imie.Text;
        string lastName = nazwisko.Text;
        string eMail = email.Text;
        User newUser = new User(firstName, lastName, eMail);
        usersCollection.InsertOne(newUser);
        Server.Transfer("UsersReview.aspx");
    }

    private void setLastId()
    {
        if (usersCollection.isNotEmpty())
        {
            var lastId = usersCollection.Aggregate<BsonDocument>(lastIdPipeline).First()["lastId"];
            MongoConnector.User.SetLastId(lastId.AsInt32);
        }
    }

}
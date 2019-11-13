using MongoConnector;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditUser : System.Web.UI.Page
{
    IMongoClient client;
    IMongoDatabase db;
    IMongoCollection<User> usersCollection;
    User user;
    protected void Page_Load(object sender, EventArgs e)
    {
        usersCollection = Utils.mongoConnection.UserCollection;
        user = Session["user"] as User;
        if (!IsPostBack)
        {
            imie.Text = user.Firstname;
            nazwisko.Text = user.Lastname;
            email.Text = user.Email;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        user.Lastname = nazwisko.Text;
        user.Firstname = imie.Text;
        user.Email = email.Text;
        usersCollection.ReplaceOne(u => u.Id == user.Id, user);
        Server.Transfer("UsersReview.aspx");
    }

}
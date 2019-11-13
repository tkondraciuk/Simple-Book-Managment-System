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
using User = MongoConnector.User;

public partial class UsersReview : Page
{
    string[] columnNames = { "Imię","Nazwisko","Email" };
    MongoClient client;
    IMongoDatabase db;
    IMongoCollection<User> usersCollection;
    GridViewAdapter gridView;
    bool lockRowCliking = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        usersCollection = Utils.mongoConnection.UserCollection;
        gridView = new GridViewAdapter(GridView1, columnNames);
        var b = usersCollection.LoadEntitiesFromDatabase<User>();
        gridView.AddMany(b);
    }
    
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var id = e.Values["Id"].ToString();
        var filter = Builders<Book>.Filter.Eq("_id", id);
        var a = usersCollection.DeleteOne(b => b.Id.Equals(id));
        Server.Transfer("UsersReview.aspx");
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string id = GridView1.getCellContent(e.NewEditIndex, 3);
        Session["user"] = usersCollection.Find(b => b.Id.Equals(id)).First();
        Server.Transfer("EditUser.aspx");
    }

    protected void szukaj_TextChanged(object sender, EventArgs e)
    {
        string fraza = szukaj.Text.ToLower();
        List<User> books = usersCollection.Find(u => u.Firstname.ToLower().Contains(fraza)
        || u.Lastname.ToLower().Contains(fraza)
        || u.Email.Contains(fraza)).ToList();

        ReloadGridView(books);
    }
    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "Szczegoly") return;
        int rowNumber = e.GetRowNumber();
        string id = GridView1.getCellContent(rowNumber, 3);
        Session["user"] = usersCollection.Find(u => u.Id.Equals(id)).First();
        Server.Transfer("UserDetails.aspx");
    }

    private void ReloadGridView(IEnumerable<User> users)
    {
        gridView.Table.Clear();
        gridView.AddMany(users);
    }
}
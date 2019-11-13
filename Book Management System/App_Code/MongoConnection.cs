using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using MongoConnector;
using MongoDB.Bson;
using MongoDB.Driver;

public class MongoConnection
{
    static readonly string configFile = HttpContext.Current.Server.MapPath("~") + @"MongoConnectionConfig.json";

    private string host;
    private string port = string.Empty;
    private string login = string.Empty;
    private string password = string.Empty;
    private string databaseName = "";
    private string userCollectionName = "";
    private string bookCollectionName = "";
    private IMongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<Book> bookCollection;
    private IMongoCollection<User> userCollection;
    private static JsonSerializerOptions jsonOptions = new JsonSerializerOptions();

    public string Host { get => host; set => host = value; }
    public string Port { get => port; set => port = value; }
    public string Login { get => login; set => login = value; }
    public string Password { get => password; set => password = value; }
    public IMongoClient Client { get => client; private set => client = value; }
    public IMongoDatabase Database { get => database; private set => database = value; }
    public IMongoCollection<Book> BookCollection { get => bookCollection; private set => bookCollection = value; }
    public IMongoCollection<User> UserCollection { get => userCollection; private set => userCollection = value; }
    public string ConnectionString { get=>getConnectionString();  }
    public string DatabaseName { get => databaseName; set => databaseName = value; }
    public string UserCollectionName { get => userCollectionName; set => userCollectionName = value; }
    public string BookCollectionName { get => bookCollectionName; set => bookCollectionName = value; }
    private static JsonSerializerOptions JsonOptions { get => jsonOptions; set => jsonOptions = value; }

    private string getConnectionString()
    {
        if (Login.Equals(string.Empty) || Password.Equals(string.Empty))
            return @"mongodb://" + Host + ":" + Port;
        else
            return @"mongodb://" + Login + ":" + Password + "@" + Host + ":" + Port;
    }

    public static MongoConnection getMongoConnection()
    {
        //JsonOptions.PropertyNameCaseInsensitive = true;
        string configJson = File.ReadAllText(configFile);
        MongoConnection mongoConnection = JsonSerializer.Deserialize<MongoConnection>(configJson, JsonOptions);
        mongoConnection.getMongoObjects();
        return mongoConnection;
    }

    private void getMongoObjects()
    {
        Client = new MongoClient(this.ConnectionString);
        Database = Client.GetDatabase(DatabaseName);
        BookCollection = Database.GetCollection<Book>(BookCollectionName);
        UserCollection = Database.GetCollection<User>(UserCollectionName);
    }
}

    
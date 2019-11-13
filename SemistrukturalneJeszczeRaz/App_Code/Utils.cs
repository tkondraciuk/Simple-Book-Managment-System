using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MongoDB.Bson;
using MongoDB.Driver;

/// <summary>
/// Summary description for Utils
/// </summary>
public static class Utils
{
    public readonly static MongoConnection mongoConnection = MongoConnection.getMongoConnection();


    public static IEnumerable<EntitiesType> LoadEntitiesFromDatabase<EntitiesType>( this IMongoCollection<EntitiesType> collection) 
    {
        return collection.Find(FilterDefinition<EntitiesType>.Empty).ToList();
    }

    public static int GetRowNumber(this GridViewCommandEventArgs eventArgs)
    {
        return Convert.ToInt32(eventArgs.CommandArgument);
    }

    public static string getCellContent(this GridView gridView, int row, int column)
    {
        return gridView.Rows[row].Cells[column].Text;
    }

    public static bool isEmpty<T>(this IMongoCollection<T> collection)
    {
        return collection.Count(FilterDefinition<T>.Empty) == 0;
    }

    public static bool isNotEmpty<T>(this IMongoCollection<T> collection)
    {
        return !collection.isEmpty();
    }
}
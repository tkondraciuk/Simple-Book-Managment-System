using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using MongoConnector;

/// <summary>
/// Summary description for GridViewAdapter
/// </summary>
public class GridViewAdapter
{
    GridView gridview;
    DataTable table;
    IEnumerable<string> columnNames;

    public DataTable Table { get { return table; } }

    public GridViewAdapter(GridView gridview, IEnumerable<string> columnNames=null)
    {
        string[] id = { "Id" };
        this.gridview = gridview;
        this.columnNames = id.Concat(columnNames);
        table = new DataTable();
        table.Columns.AddRange(this.columnNames.Select(cn => new DataColumn(cn)).ToArray());
        gridview.DataBind();
        //gridview.Columns[2].Visible = false;
    }
    public void Add(Book newBook)
    {
        DataRow row = table.NewRow();
        string[] record = newBook;
        for (int i = 0; i < columnNames.Count(); i++)
        {
            string key = columnNames.ElementAt(i);
            string value = record.ElementAt(i);
            row[key] = value;
        }
        table.Rows.Add(row);
        gridview.DataSource = table;
        gridview.DataBind();
    }
    public void Add(User newUser)
    {
        DataRow row = table.NewRow();
        string[] record = newUser;
        for (int i = 0; i < columnNames.Count(); i++)
        {
            string key = columnNames.ElementAt(i);
            string value = record.ElementAt(i);
            row[key] = value;
        }
        table.Rows.Add(row);
        gridview.DataSource = table;
        gridview.DataBind();
    }


    public void AddMany(IEnumerable<Book> newBooks)
    {
        foreach (var record in newBooks)
        {
            Add(record);
        }
    }
    public void AddMany(IEnumerable<User> newUser)
    {
        foreach (var record in newUser)
        {
            Add(record);
        }
    }

    public void Remove(int index)
    {
        table.Rows.RemoveAt(index);
        gridview.DataBind();
    }
    public void RemoveMany(IEnumerable<int> indexes)
    {
        foreach (var index in indexes)
        {
            Remove(index);
        }
    }

    public void Update(int index, IEnumerable<string> changes)
    {
        if (changes.Count() != columnNames.Count()) throw new Exception("Liczba elementów zmian musi być równa liczbie kolumn");

        for (int i = 0; i < columnNames.Count(); i++)
        {
            string key = columnNames.ElementAt(i);
            string value = changes.ElementAt(i);
            if (value != null)
                table.Rows[index][key] = value;
        }
        gridview.DataBind();
    }
    public void UpdateMany(IEnumerable<int> indexes, IEnumerable<IEnumerable<string>> changes)
    {
        if (indexes.Count() != changes.Count())
            throw new Exception("Liczba indeksów i liczba rekordów do zmiany musi być równa");

        for (int i = 0; i < indexes.Count(); i++)
        {
            int index = indexes.ElementAt(i);
            IEnumerable<string> change = changes.ElementAt(i);
            Update(index, change);
        }
            
    }
}
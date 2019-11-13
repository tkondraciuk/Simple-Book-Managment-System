using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MongoConnector
{
    public class Book
    {
        public readonly static string[] columnName = { "Lp", "Autor", "Tytuł", "Cykl", "Gatunek" };

        static int lastId = 0;

        int id;

        string author;

        string title;

        string series;

        string gentle;

        int totalNumber;

        int availableNumber;

        public Book(string author, string title, string series, string gentle, int number)
        {
            LastId++;
            this.Id = LastId;
            this.author = author;
            this.title = title;
            this.series = series;
            this.gentle = gentle;
            this.TotalNumber = number;
            AvailableNumber = number;
        }

        public static int LastId { get => lastId; private set => lastId = value; }

        public int Id { get => id; set => id = value; }
        public string Author { get => author; set => author = value; }
        public string Title { get => title; set => title = value; }
        public string Series { get => series; set => series = value; }
        public string Gentle { get => gentle; set => gentle = value; }
        public int TotalNumber { get => totalNumber; set => totalNumber = value; }
        public int AvailableNumber { get => availableNumber; set => availableNumber = value; }

        public static Book ConvertToBook(IEnumerable<string> data)
        {
            int id = Convert.ToInt32(data.ElementAt(0));
            string autor = data.ElementAt(1);
            string tytul = data.ElementAt(2);
            string cykl = data.ElementAt(3);
            string gatunek = data.ElementAt(4);
            int ilosc = Convert.ToInt32(data.ElementAt(5));
            return new Book(autor, tytul, cykl, gatunek, ilosc);
        }

        public static void setLastId(int id)
        {
            LastId = id;
        }

        public static implicit operator string[] (Book b)
        {
            string ilość = b.AvailableNumber + "/" + b.TotalNumber;
            string[] result = { b.Id.ToString(), b.Author, b.Title, b.Series, b.Gentle,  ilość};
            return result;
        }
    }
}

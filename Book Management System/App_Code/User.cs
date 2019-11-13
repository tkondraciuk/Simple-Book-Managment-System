using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MongoConnector
{
    public class User
    {
        public readonly static string[] columnName = { "Lp", "Imię", "Nazwisko", "E-mail"};

        static int lastId = 0;

        int id;

        string firstname;

        string lastname;

        string email;

        List<int> rentedBooksIds = new List<int>();
       

        public User(string firstname, string lastname, string email)
        {
            LastId++;
            this.id = LastId;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
        }

        public static int LastId { get => lastId; private set => lastId = value; }

        public int Id { get => id; set => id = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Email { get => email; set => email = value; }
        public List<int> RentedBooksIds { get => rentedBooksIds; set => rentedBooksIds = value; }

        public static User ConvertToUser(IEnumerable<string> data)
        {
            int id = Convert.ToInt32(data.ElementAt(0).Remove(0, 4));
            string imie = data.ElementAt(1);
            string nazwisko = data.ElementAt(2);
            string email = data.ElementAt(3);
            return new User(imie, nazwisko, email);
        }

        public static void SetLastId(int id)
        {
            LastId = id;
        }

        public static implicit operator string[] (User u)
        {
            string[] result = {u.id.ToString(), u.Firstname, u.Lastname, u.Email};
            return result;
        }
    }
}

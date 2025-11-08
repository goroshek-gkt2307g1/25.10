using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._10.Models.Entities
{
    public class User(int id, string username, string phone, string info, int rating) : PropertyChangedBase
    {
        
        private string _username = username;
        private string _phone = phone;
        private string _info = info;
        private int _rating = rating;

        public int Id
        {
            get;
            init;
        } = id;

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(); }
        }

        public string Information
        {
            get { return _info; }
            set { _info = value; OnPropertyChanged(); }
        }

        public int Rating
        {
            get { return _rating; }
            set { _rating = value; OnPropertyChanged(); }
        }
    }
}

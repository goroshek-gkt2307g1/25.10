using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _25._10.Models.Entities
{
    public class Course(int id, string title, string description, DateTime creationDate,
        string mentor, string status) : Entity
    {
        private string _title = title;
        private string _description = description;
        private DateTime _creationDate = creationDate;
        private string _mentor = mentor;
        private string _status = status;

        public int Id
        {
            get;
            init;
        } = id;

        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }

        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; OnPropertyChanged(); }
        }

        public string Mentor
        {
            get { return _mentor; }
            set { _mentor = value; OnPropertyChanged(); }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(); }
        }

    }
}

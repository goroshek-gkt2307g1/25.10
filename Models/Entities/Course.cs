using _25._10.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _25._10.Models.Entities
{
    public class Course(int id, string title, string description, string mentor, string status) : PropertyChangedBase
    {
        private string _title = title;
        private string _description = description;
        private string _mentor = mentor;
        private string _status = status;


        public int CourseId { get; init; } = id;

        public string CourseTitle
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }

        public string CourseDescription
        {
            get => _description;
            set { _description = value; OnPropertyChanged(); }
        }

        public string Mentor
        {
            get => _mentor;
            set { _mentor = value; OnPropertyChanged(); }
        }

        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }

        public string UserEnrollmentStatus { get; set; } = "NOT_APPLIED";

        public Course() : this(0, "", "", "", "")
        {
        }

    }
}

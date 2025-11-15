using _25._10.Models.Entities;
using System;
using System.Collections.Generic;

namespace _25._10.Models.Entities.Entities;

public class Course(int courseid, string coursetitle, string coursedescription, string mentor, string status) : PropertyChangedBase
{
    private string _title = coursetitle;
    private string _description = coursedescription;
    private string _mentor = mentor;
    private string _status = status;

    public int CourseId { get; set; }

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

    public DateTime? CreationDate { get; set; }

    public int MentorIdFk { get; set; }

    public int CourseStatusIdFk { get; set; }

    public virtual CourseStatus CourseStatusIdFkNavigation { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Account MentorIdFkNavigation { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}

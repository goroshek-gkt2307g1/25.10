using System;
using System.Collections.Generic;

namespace _25._10.Entities;

public partial class CourseStatus
{
    public int CourseStatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}

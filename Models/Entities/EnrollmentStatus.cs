using System;
using System.Collections.Generic;
using _25._10.Entities;

namespace _25._10.Models.Entities;

public partial class EnrollmentStatus
{

    public int EnrollmentStatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

}

public enum EnrollmentStatusType
{
    NOT_APPLIED = 0,
    PENDING = 1,
    APPROVED = 2,
    REJECTED = 3
}

using System;
using System.Collections.Generic;

namespace ITIRazor.Models;

public partial class Department
{
    public int DeptId { get; set; }

    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}

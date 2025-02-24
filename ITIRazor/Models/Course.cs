using System;
using System.Collections.Generic;

namespace ITIRazor.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Duration { get; set; }

    public int DeptId { get; set; }

    public virtual Department Dept { get; set; } = null!;
}

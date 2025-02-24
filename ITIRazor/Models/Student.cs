using System;
using System.Collections.Generic;

namespace ITIRazor.Models;

public partial class Student
{
    public int StdId { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public int DeptId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Department Dept { get; set; } = null!;
}

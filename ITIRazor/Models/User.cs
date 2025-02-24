using System;
using System.Collections.Generic;

namespace ITIRazor.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}

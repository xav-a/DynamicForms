using System;
using System.Collections.Generic;

namespace DynForms.Server.Models;

public partial class Form
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string DisplayName { get; set; } = null!;

    public bool Enabled { get; set; }

    public virtual ICollection<Field> Fields { get; set; } = new List<Field>();
}

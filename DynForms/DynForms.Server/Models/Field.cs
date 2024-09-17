using System;
using System.Collections.Generic;

namespace DynForms.Server.Models;

public partial class Field
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public short? Width { get; set; }

    public string? Type { get; set; }

    public bool Enabled { get; set; }

    public int? FormId { get; set; }

    public virtual Form? Form { get; set; }
}

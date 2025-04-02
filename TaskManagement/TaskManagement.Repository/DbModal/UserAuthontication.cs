using System;
using System.Collections.Generic;

namespace TaskManagement.Repository.DbModal;

public partial class UserAuthontication
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Token { get; set; }

    public bool? IsActive { get; set; }

    public int? Userid { get; set; }

    public virtual Employee? User { get; set; }
}

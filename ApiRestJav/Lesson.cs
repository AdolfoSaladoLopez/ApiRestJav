using System;
using System.Collections.Generic;

namespace ApiRestJav;

public partial class Lesson
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string FirstDescription { get; set; } = null!;

    public byte[]? FirstImage { get; set; }

    public string SecondDescription { get; set; } = null!;

    public byte[]? SecondImage { get; set; }

    public string? ThirdDescription { get; set; }

    public int UserId { get; set; }

    public bool Completed { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual Character User { get; set; } = null!;

    public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
}

using System;
using System.Collections.Generic;

namespace ApiRestJav;

public partial class Character
{
    public int Id { get; set; }

    public int Level { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
}

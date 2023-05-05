using System;
using System.Collections.Generic;

namespace ApiRestJav;

public partial class Weapon
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? Date { get; set; }

    public int LessonId { get; set; }

    public int? UserId { get; set; }

    public byte[]? Image { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual Character? User { get; set; }
}

using System;
using System.Collections.Generic;

namespace ApiRestJav;

public partial class Question
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Question1 { get; set; } = null!;

    public int LessonId { get; set; }

    public byte[]? Image { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Lesson Lesson { get; set; } = null!;
}

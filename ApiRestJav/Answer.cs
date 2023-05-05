using System;
using System.Collections.Generic;

namespace ApiRestJav;

public partial class Answer
{
    public int Id { get; set; }

    public string Answer1 { get; set; } = null!;

    public bool Correct { get; set; }

    public int QuestionId { get; set; }

    public byte[]? Image { get; set; }

    public virtual Question Question { get; set; } = null!;
}

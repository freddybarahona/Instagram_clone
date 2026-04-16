using System;
using System.Collections.Generic;

namespace InstagramClone.Domain.Database.SqlServer.Entities;

public partial class PostMention
{
    public Guid PostId { get; set; }

    public Guid UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

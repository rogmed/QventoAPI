using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QventoAPI.Data;

public partial class Qvento
{
    public int QventoId { get; set; }

    public int CreatedBy { get; set; }

    public string Title { get; set; } = null!;

    public DateTime DateOfQvento { get; set; }

    public DateTime DateCreated { get; set; }

    [RegularExpression("[ACF]",
         ErrorMessage = "Status must be A (Active), C (Cancelled) or F (Finished)")]
    public string Status { get; set; } = null!;

    public string? Description { get; set; }

    public string? Location { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Invitation> Invitations { get; } = new List<Invitation>();

    
}

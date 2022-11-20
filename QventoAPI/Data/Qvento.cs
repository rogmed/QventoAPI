using System;
using System.Collections.Generic;

namespace QventoAPI.Data;

public class Qvento
{
    public int QventoId { get; set; }

    public int CreatedBy { get; set; }

    public string Title { get; set; } = null!;

    public DateTime DateQvento { get; set; }

    public DateTime DateCreated { get; set; }

    public string Status { get; set; } = null!;

    public string? Description { get; set; }

    public string? Address { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Invitation> Invitations { get; } = new List<Invitation>();
}

/*
    public class Qvento
    {
        [Required]
        public string QventoId { get; set; }
        
        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime DateOfQvento { get; set; }
        public DateTime DateCreated { get; set; }

        [RegularExpression(@"^ACF$",
         ErrorMessage = "Status must be A (Active), C (Cancelled) or F (Finished)")]
        public string Status { get; set; }
    }
*/
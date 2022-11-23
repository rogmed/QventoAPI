namespace QventoAPI.Data;

public partial class Invitation
{
    public int QventoId { get; set; }

    public int UserId { get; set; }

    public string Status { get; set; } = null!;

    public virtual Qvento Qvento { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

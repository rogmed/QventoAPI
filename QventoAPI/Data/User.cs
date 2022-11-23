namespace QventoAPI.Data;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Invitation> Invitations { get; } = new List<Invitation>();

    public virtual ICollection<Qvento> Qventos { get; } = new List<Qvento>();
}

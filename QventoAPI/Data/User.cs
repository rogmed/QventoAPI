using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace QventoAPI.Data;

[JsonObject(MemberSerialization.OptIn)]
public partial class User
{
    public int UserId { get; set; }

    [JsonProperty]
    public string Name { get; set; } = null!;

    [JsonProperty]
    public string LastName { get; set; } = null!;

    [JsonProperty]
    public string Email { get; set; } = null!;

    [JsonIgnore]
    public string PasswordHash { get; set; } = null!;

    [JsonIgnore]
    public string? Phone { get; set; }

    [JsonIgnore]
    public string? Address { get; set; }

    [JsonIgnore]
    public string? TempToken { get; set; }

    [JsonIgnore]
    public virtual ICollection<Invitation> Invitations { get; } = new List<Invitation>();

    [JsonIgnore]
    public virtual ICollection<Qvento> Qventos { get; } = new List<Qvento>();
}

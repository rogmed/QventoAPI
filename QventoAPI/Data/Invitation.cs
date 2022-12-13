using Newtonsoft.Json;

namespace QventoAPI.Data;

[JsonObject(MemberSerialization.OptIn)]
public partial class Invitation
{
    [JsonIgnore]
    public int QventoId { get; set; }

    [JsonIgnore]
    public int UserId { get; set; }

    [JsonProperty]
    public string Status { get; set; } = null!;

    [JsonIgnore]
    public virtual Qvento Qvento { get; set; } = null!;

    [JsonProperty]
    public virtual User User { get; set; } = null!;
}

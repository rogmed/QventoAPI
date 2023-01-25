using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace QventoAPI.Data;

[JsonObject(MemberSerialization.OptIn)]
public partial class Qvento
{
    [JsonProperty]
    public int QventoId { get; set; }

    [JsonProperty]
    public int CreatedBy { get; set; }

    [JsonProperty]
    public string Title { get; set; } = null!;

    [JsonProperty]
    public DateTime DateOfQvento { get; set; }

    [JsonProperty]
    public DateTime DateCreated { get; set; }

    [JsonProperty]
    [RegularExpression("[ACF]",
         ErrorMessage = "Status must be A (Active), C (Cancelled) or F (Finished)")]
    public string Status { get; set; } = null!;

    [JsonProperty]
    public string? Description { get; set; }

    [JsonProperty]
    public string? Location { get; set; }

    [JsonProperty]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [JsonProperty]
    public virtual ICollection<Invitation> Invitations { get; } = new List<Invitation>();


}

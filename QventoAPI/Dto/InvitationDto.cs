using System.ComponentModel.DataAnnotations;

namespace QventoAPI.Dto
{
    public class InvitationDto
    {
        [Required]
        public int QventoId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [RegularExpression("[PAR]",
            ErrorMessage = "Status must be P (Pending), A (Aaccepted) or R (Rejected)")]
        public string? Status { get; set; }
    }

    public class NewInvitationDto
    {
        [Required]
        public int QventoId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}

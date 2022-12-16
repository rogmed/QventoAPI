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

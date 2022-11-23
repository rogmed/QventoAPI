using QventoAPI.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QventoAPI.Dto
{
    public class QventoDto
    {
        [ReadOnly(true)]
        public int QventoId { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public DateTime DateOfQvento { get; set; }

        [ReadOnly(true)]
        public DateTime DateCreated { get; set; }

        [Required]
        [RegularExpression("[ACF]",
             ErrorMessage = "Status must be A (Active), C (Cancelled) or F (Finished)")]
        public string Status { get; set; } = null!;

        public string? Description { get; set; }

        public string? Location { get; set; }
    }
}

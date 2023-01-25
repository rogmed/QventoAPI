using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QventoAPI.Dto
{
    public class OutgoingQventoDto : QventoDto
    {
        [ReadOnly(true)]
        public int QventoId { get; set; }

        [ReadOnly(true)]
        public DateTime DateCreated { get; set; }

        [Required]
        [RegularExpression("[ACF]",
            ErrorMessage = "Status must be A (Active), C (Cancelled) or F (Finished)")]
        public string Status { get; set; } = null!;

    }
    public class QventoDto : NewQventoDto
    {
        [Required]
        public int CreatedBy { get; set; }

        public QventoDto(int userId, NewQventoDto dto) : base()
        {
            this.CreatedBy = userId;
            this.Title = dto.Title;
            this.DateOfQvento = dto.DateOfQvento;
            this.Description = dto.Description;
            this.Location = dto.Location;
        }

        public QventoDto()
        {
        }
    }

    public class NewQventoDto
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public DateTime DateOfQvento { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }

        public NewQventoDto()
        {
        }
    }
}

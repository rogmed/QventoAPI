using System.ComponentModel.DataAnnotations;

namespace QventoAPI
{
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
}

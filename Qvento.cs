using System.ComponentModel.DataAnnotations;

namespace QventoAPI
{
    public class Qvento
    {
        [Required]
        public string QventoId { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
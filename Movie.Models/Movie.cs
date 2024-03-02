
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0, 500)]
        public int Duration { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }
    }
}

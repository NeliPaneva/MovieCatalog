using System.ComponentModel.DataAnnotations;

namespace Movie.Web.Models
{
    public class BindingMovie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0, 500)]
        public int Duration { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CompanyId { get; set; }

        public int DirectorId { get; set; }

    }
}


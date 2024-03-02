
using System.ComponentModel.DataAnnotations;


namespace Movie.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}

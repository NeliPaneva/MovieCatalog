
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{/// <summary>
/// model on movie for database
/// </summary>
    public class Movie
    {   //primary key 
        public int Id { get; set; }
        //movie name
        [Required]
        public string Name { get; set; }
        //Movie duration in mimutes
        [Range(0, 500)]
        public int Duration { get; set; }
        //Date on creating - month end year
        [DataType(DataType.Date)]
        public DateTime? CreatedOn { get; set; }
        //foreign key for company creater
        public int CompanyId { get; set; }
        //navigation property for company creator
        public virtual Company Company { get; set; }
        //foreign key for Director of movie
        public int DirectorId { get; set; }
        //navigation property for Director
        public virtual Director Director { get; set; }
    }
}

using Movie.Models;
using System.ComponentModel.DataAnnotations;

namespace Movie.Web.Models
{
    public class MovieGroup
    {
        
        public string CompanyName { get; set; }

        public int MovieCount { get; set; }
    }
}

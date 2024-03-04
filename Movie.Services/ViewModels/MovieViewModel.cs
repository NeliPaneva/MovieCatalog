using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Services.ViewModels
{
    public class MovieViewModel
    {
        public string Name { get; set; }
        public int  Duration { get; set; }
        public string CreatedOn { get; set; }
        public string DiraectorName { get; set; }
        public string CompanyName { get; set; }
    }
}

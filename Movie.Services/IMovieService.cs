using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Services
{
    public interface IMovieService
    {
        void Create(string name, int duration, string companyName, string directorName);
        ICollection<string> GetAll();
    }
}

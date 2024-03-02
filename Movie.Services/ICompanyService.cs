using Movie.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Services
{
    public interface ICompanyService
    {
        void Create(string companyName);
        void Delete(string companyName);
        CompanyViewModel Fetch(int Id);
        void Update(string OldCompanyName, string NewCompanyName);
        ICollection<string> GetAll();


    }
}

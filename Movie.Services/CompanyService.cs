using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;
using Movie.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly MovieContext db;

        public CompanyService(MovieContext db)
        {
                this.db=db;
        }
        public void Create(string companyName)
        {
            Company c= new Company();
            c.Name = companyName;
            db.Companies.Add(c);
            db.SaveChanges();
        }

        public void Delete(string companyName)
        {
            var comp = db.Companies.FirstOrDefault(x => x.Name == companyName);
            if (comp != null)
            {
                db.Companies.Remove(comp);
            }
            else
            {
                Console.WriteLine($"Not found company with name {companyName}");
            }
            db.SaveChanges();
        }

        public CompanyViewModel Fetch(int id)
        {
            var cvm = new CompanyViewModel();
            var comp = db.Companies.FirstOrDefault(x => x.Id == id);
            if (comp != null)
            {
                cvm.Id = comp.Id;
                cvm.Name = comp.Name;
                return cvm;
            }
            else return null;
            
        }

        public ICollection<string> GetAll()
        {
            return db.Companies.Select(x=>x.Name).ToList();
        }

        public void Update(string OldCompanyName, string NewCompanyName)
        {
           var comp= db.Companies.FirstOrDefault(x => x.Name == OldCompanyName);
            if (comp!=null)
            {
                comp.Name= NewCompanyName;
            }
            else
            {
                Console.WriteLine($"Not found company with name {OldCompanyName}");
            }
            db.SaveChanges();
        }
    }
}


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Console
{   using Movie.Data;
    using Movie.Services;
    using System;


    
    public class Display
    {
        private int closeOperationId = 8;
        private readonly CompanyService compService;
        private readonly MovieService movieService;
        private readonly MovieContext db;

        public Display()
        {
            this.db = new MovieContext();
            db.Database.EnsureCreated();
            this.compService = new CompanyService(db);
            this.movieService=new MovieService(db);
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all companies");
            Console.WriteLine("2. Add new company");
            Console.WriteLine("3. Update company");
            Console.WriteLine("4. Fetch company by ID");
            Console.WriteLine("5. Delete company by name");
            Console.WriteLine("6. Create movie");
            Console.WriteLine("7. List all movies");
            Console.WriteLine("8. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAllCompanies();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    case 6:
                        CreateMovie();
                        break;
                    case 7:
                        ListAllMoviesByViewModel();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }

        private void Delete()
        {
            Console.WriteLine("Enter company name to update: ");
            string oldName = Console.ReadLine();
            compService.Delete(oldName);
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            var cvm=compService.Fetch(id);
            if (cvm != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + cvm.Id);
                Console.WriteLine("Name: " + cvm.Name);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }

        private void Update()
        {
            //Console.WriteLine("Enter ID to update: ");
            //int id = int.Parse(Console.ReadLine());
            //Product product = productBusiness.Get(id);
            //if (product != null)
            //{
            //    Console.WriteLine("Enter name: ");
            //    product.Name = Console.ReadLine();
            //    Console.WriteLine("Enter price: ");
            //    product.Price = decimal.Parse(Console.ReadLine());
            //    Console.WriteLine("Enter availability: ");
            //    product.Stock = int.Parse(Console.ReadLine());
            //    productBusiness.Update(product);
            //}
            //else
            //{
            //    Console.WriteLine("Product not found!");
            //}
            Console.WriteLine("Enter company name to update: ");
            string oldName=Console.ReadLine();
            Console.WriteLine("Enter company new name: ");
            string newName = Console.ReadLine();
            compService.Update(oldName, newName);

        }

        private void Add()
        {
            
         
            Console.WriteLine("Enter company name: ");
            string compName = Console.ReadLine();
            compService.Create(compName);
            // db.Add(product);
        }

        private void ListAllCompanies()
        {
            //Console.WriteLine(new string('-', 40));
            //Console.WriteLine(new string(' ', 16) + "PRODUCTS" + new string(' ', 16));
            //Console.WriteLine(new string('-', 40));
            //var products = productBusiness.GetAll();
            //foreach (var item in products)
            //{
            //    Console.WriteLine("{0} {1} {2} {3}", item.Id, item.Name, item.Price, item.Stock);
            //}
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Companies" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var compNamesAll = compService.GetAll();
            foreach (var item in compNamesAll)
            {
                Console.WriteLine(item);
            }


        }
        private void CreateMovie()
        {
           
            Console.WriteLine("Enter movie name: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter duration: ");
            int duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter company name: ");
            string cName = Console.ReadLine();
            Console.WriteLine("Enter director name: ");
            string dName = Console.ReadLine();
            movieService.Create(Name,duration,cName,dName);
        }
        private void ListAllMovies()
        {
           
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Movies" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var movieAll = movieService.GetAll();
            foreach (var item in movieAll)
            {
                Console.WriteLine(item);
            }


        }
        private void ListAllMoviesByViewModel()
        {

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Movies" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var movieAll = movieService.GetAllMovies();
            foreach (var item in movieAll)
            {
                Console.WriteLine($"{item.Name} --- {item.Duration}  --- {item.DiraectorName}  --- {item.CompanyName}");
            }


        }
    }
}

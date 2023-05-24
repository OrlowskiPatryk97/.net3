using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using FizzBuzzWeb.Models;
using Microsoft.EntityFrameworkCore;
using FizzBuzzWeb.Data;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _context;
        /*[BindProperty]
        public FizzBuzzForm? FizzBuzz { get; set; }
        [BindProperty(SupportsGet =true)]
        public string? Name { get; set; }
        public List<string> lista = new List<string>();
        public string? output { get; set; }*/
        [BindProperty]
        public Person Person { get; set; }

        public IList<Person>? People { get; set; }

  
        public IndexModel(ILogger<IndexModel> logger, PeopleContext context)
        {
            _logger = logger;
            _context = context;
        }
        public void OnGet()
        {
            People = _context.Person.ToList();

        }

        public IActionResult OnPost()
        {
            People = _context.Person.ToList();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Person.Add(Person);
            _context.SaveChanges();
            return RedirectToPage("./Index");
            /*var data = HttpContext.Session.GetString("Lista");

            if (data != null)
            {
                lista = JsonConvert.DeserializeObject<List<string>>(data);
            }


            if (ModelState.IsValid)
            {
                output = FizzBuzz.wypisz();

                string noweDane = FizzBuzz.Name + ' ' + FizzBuzz.Number;
                if (FizzBuzz.przestepny() == true)
                {
                    noweDane += " jest przestepny";
                }
                else 
                {
                    noweDane += " nie jest przestepny";
                }
                lista.Add(noweDane);
                HttpContext.Session.SetString("Lista",JsonConvert.SerializeObject(lista));
                
            }
            return Page();

            */

        }

    }
}
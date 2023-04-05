using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FizzBuzzForm FizzBuzz { get; set; }
        [BindProperty(SupportsGet =true)]
        public string? Name { get; set; }
        public List<string> lista = new List<string>();
        public string? output { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            /*if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }*/

        }

        public IActionResult OnPost()
        {
            var data = HttpContext.Session.GetString("Lista");

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


           
        }

    }
}
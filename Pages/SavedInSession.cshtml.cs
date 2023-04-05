using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace FizzBuzzWeb.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public FizzBuzzForm ?FizzBuzz { get; set; }
        public List<string> numbers = new List<string>();
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Lista");
            if (Data != null)
            {
                numbers = JsonConvert.DeserializeObject<List<string>>(Data);
                
            }

        }

    }
}

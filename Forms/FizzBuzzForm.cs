using System.ComponentModel.DataAnnotations;
namespace FizzBuzzWeb.Forms
{
    public class FizzBuzzForm
    {
        //[Display(Name = "Twój szczęśliwy numerek")]
        [Required]
        [Range(1899, 2022, ErrorMessage = "Błędna wartość ")]//Oczekiwana wartość {0} z zakredu {1} i {2}.
        public int Number { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Za długi ciąg znaków")]
        public string? Name { get; set; }


        public bool? przestepny() 
        {
            if(this.Number%4==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string? wypisz()
        {
            if (przestepny()==true)
            {
                return this.Name +' '+ this.Number + ' ' + "jest przestepny";
            }
            else
            {
                return this.Name + ' ' + this.Number + ' ' + "nie jest przestepny";
            }
        }

    }
}

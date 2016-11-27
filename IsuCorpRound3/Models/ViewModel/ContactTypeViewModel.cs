using System.ComponentModel.DataAnnotations;

namespace IsuCorpRound3.Models.ViewModel
{
    public class ContactTypeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Name")]
        public string name { get; set; }


        [Required(ErrorMessage = "*")]
        [Display(Name = "Description")]
        public string description { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace IsuCorpRound3.Models.ViewModel
{
    public class ContactTypeModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string name { get; set; }


        [Required(ErrorMessage = "*")]
        public string description { get; set; }
    }
}
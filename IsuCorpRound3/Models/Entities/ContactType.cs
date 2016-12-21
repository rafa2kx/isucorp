using System.ComponentModel.DataAnnotations;

namespace IsuCorpRound3.Models.Entities
{
    public class ContactType
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsuCorpRound3.Models.Entities
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }

        public string Fullname { get; set; }

        public DateTime? Birthdate { get; set; }

        public string Description { get; set; }

        
        public int? ContactTypeID { get; set; }

        [ForeignKey("ContactTypeID" )]
        public ContactType ContactType { get; set; }

        public string PhoneNumber { get; set; }

        public short? Rating { get; set; }

        public bool? IsFavorite { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using IsuCorpRound3.Properties;

namespace IsuCorpRound3.Models.ViewModel
{
    public class ReservationModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(ResourceType = typeof (Resources), Name = "FULLNAME")]
        public string Fullname { get; set; }
        

        [Required(ErrorMessage = "*")]
        [Display(ResourceType = typeof (Resources), Name = "BIRTHDATE")]
        public DateTime? Birthdate { get; set; }

        [Display(ResourceType = typeof (Resources), Name = "DESCRIPTION")]
        [AllowHtml]
        public string Description { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(ResourceType = typeof (Resources), Name = "CONTACT_TYPE")]
        public int? ContactTypeId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(ResourceType = typeof (Resources), Name = "PHONE_NUMBER")]
        public string PhoneNumber { get; set; }
        
        [Range(1, 5)]
        public short? Rating { get; set; }

        public bool? IsFavorite { get; set; }
    }
}
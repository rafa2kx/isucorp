using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IsucorpDataAccess.Models.ViewModel
{
    public partial class ReservationModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string Fullname { get; set; }
        

        [Required(ErrorMessage = "*")]
        public DateTime? Birthdate { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        [Required(ErrorMessage = "*")]
        public int? ContactTypeId { get; set; }

        [Required(ErrorMessage = "*")]
        public string PhoneNumber { get; set; }
        
        [Range(1, 5)]
        public short? Rating { get; set; }

        public bool? IsFavorite { get; set; }
    }
}
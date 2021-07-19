using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helper.Models
{
    public class Medicines
    {
        public int id { get; set; }
        [Display(Name = "Name Of Medicine"), Required]
        public String name { get; set; }
        [Required]
        public int? NoOfPiece { get; set; }
        [Required]
        public float? price { get; set; }
        public Pharmecy pharmecy { get; set; }
        public int pharmecyId { get; set; }

        public Boolean addToCart { get; set; }
        public int noOfCategory { get; set; }
    }
}
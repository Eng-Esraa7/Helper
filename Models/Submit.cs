using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helper.Models
{
    public class Submit
    {
        public int id { get; set; }
        public bool done { get; set; }
        [Required]
        [Display(Name ="Name")]
        public String name { get; set; }
        [Required]
        public String Phone { get; set; }
        public Doners doners { get; set; }
        [Display(Name = "Name Of Doner")]
        public int DonersId { get; set; }
    }
}
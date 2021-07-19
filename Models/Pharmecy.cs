using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helper.Models
{
    public class Pharmecy
    {
        public int id { get; set; }
        [Display(Name = "Name Of Medicine"), Required]
        public String Name { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Phone { get; set; }
        [Required]
        public String Location { get; set; }
    }
}
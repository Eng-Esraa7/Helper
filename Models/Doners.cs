using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helper.Models
{
    public class Doners
    {
        public int id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Phone { get; set; }
        [Required]
        [noofoxygen]
        [Display(Name="Number Of Oxygen Pipes")]
        public int NoOfOxgen { get; set; }
        public String Location { get; set; }
        public Boolean notification { get; set; }

    }
}
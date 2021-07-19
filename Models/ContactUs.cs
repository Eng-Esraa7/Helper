using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helper.Models
{
    public class ContactUs
    {
        public int id { get; set; }
        [StringLength(100),Required]
        public string FullName { get; set; }
        [StringLength(100), Required]
        public string Email { get; set; }
        [StringLength(100), Required]
        public string Message { get; set; }
        [StringLength(15), Required]
        public string PhoneNumber { get; set; }
    }
}
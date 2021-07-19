using Helper.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helper.Models
{
    public class AddtoCart
    {
        public int id { get; set; }
        public int medId { get; set; }
        public String name { get; set; }
        public float price { get; set; }
        public int noCategory { get; set; }
        public String UserId { get; set; }
        public Boolean check{get;set;}
}
}
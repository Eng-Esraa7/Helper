using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helper.Models
{
    public class newDonors
    {
        public Doners doners { get; set; }
        public IEnumerable<Doners> Doners { get; set; }
        public Submit submit { get; set; }
        public IEnumerable<Submit> SubmitList { get; set; }
    }
}
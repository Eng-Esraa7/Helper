using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helper.Models
{
    public class newModelMedicine
    {
        public IEnumerable<Pharmecy> pharmecy { get; set; }
        public Medicines medicines { get; set; }
        public IEnumerable<Medicines> medList { get; set; }
        public IEnumerable<AddtoCart> addtoCart { get; set; }
        public IEnumerable<checkOut> checkOutlist { get; set; }
        public checkOut checkOut { get; set; }
    }
}
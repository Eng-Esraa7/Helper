using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Helper.Models
{
    public class noofoxygen : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var donors = (Doners)validationContext.ObjectInstance;
            return (donors.NoOfOxgen==null || donors.NoOfOxgen == 0) ? new ValidationResult("No Of Oxygen Pipes Required") : ValidationResult.Success;
        }
    }
}
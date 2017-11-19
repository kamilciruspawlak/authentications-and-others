using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace adresyIOsoby.Valid
{
    public class AdressValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var regex = new Regex("^[0-9]{2}-[0-9]{3}$");
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (regex.IsMatch(value.ToString()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("No sory ale to nie dziala");
        }

    }
}
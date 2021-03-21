using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_API.Attributes
{
    public class NumberRangeAttribute : ValidationAttribute
    {
        public string fieldName { get; set; }
        public int minNum { get; set; }
        public int maxNum { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user_value = Convert.ToDouble(value);
            if(user_value >= minNum && user_value <= maxNum)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($@"The {fieldName} must be greater than {minNum} and less than {maxNum}");
            }
        }

    }
}
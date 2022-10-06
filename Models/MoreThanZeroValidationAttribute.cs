using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_post.Models
{
    public class MoreThanZeroValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if((double)value <= 0)
            {
                return new ValidationResult("Il prezzo deve essere maggiore di 0");
            }

            return ValidationResult.Success;
        }
    }
}

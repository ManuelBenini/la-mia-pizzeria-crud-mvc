using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeri_crud_mvc.Models
{
    public class MoreThanZeroValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if((decimal)value <= 0)
            {
                return new ValidationResult("Il prezzo deve essere maggiore di 0");
            }

            return ValidationResult.Success;
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Validations
{
    public class MoreThanZeroValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if ((decimal)value <= 0)
                {
                    return new ValidationResult("Il prezzo deve essere maggiore di 0");
                }
            }

            return ValidationResult.Success;
        }
    }
}

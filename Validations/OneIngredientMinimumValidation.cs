using System.ComponentModel.DataAnnotations;

namespace Validations
{
    public class OneIngredientMinimumValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<int> valueList = (List<int>)value;

            if (valueList.Count == 0)
            {
                return new ValidationResult("Deve inserire almeno un ingrediente");
            }

            return ValidationResult.Success;
        }
    }
}

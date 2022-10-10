using System.ComponentModel.DataAnnotations;

namespace Validations
{
    public class MoreThanFiveWordsValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string fieldValue = (string)value;
            List<string> words = new();

            if (fieldValue != null)
            {
                foreach (string word in fieldValue.Split(' '))
                {
                    words.Add(word);
                }

                if (words.Count < 5)
                {
                    return new ValidationResult("Il campo descrizione deve contenere almeno 5 parole.");
                }
            }

            return ValidationResult.Success;
        }
    }
}

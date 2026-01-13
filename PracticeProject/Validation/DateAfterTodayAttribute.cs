using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Validation
{
    public class DateAfterTodayAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            if (value is not DateTime date)
                return ValidationResult.Success;

            if (date.Date <= DateTime.Today)
                return new ValidationResult(
                    "Due date must be after today.");

            return ValidationResult.Success;
        }
    }
}

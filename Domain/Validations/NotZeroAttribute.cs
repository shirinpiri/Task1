using System.ComponentModel.DataAnnotations;

namespace Domain.Validations
{
    public class NotZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value) => (double)value != 0;
    }
}

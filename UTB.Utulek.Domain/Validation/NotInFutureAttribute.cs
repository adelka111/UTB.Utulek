using System.ComponentModel.DataAnnotations;

namespace UTB.Utulek.Domain.Validation;

[AttributeUsage(AttributeTargets.Property)]
public class NotInFutureAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is null) return true;
        return value is DateTime date && date <= DateTime.Today;
    }
}
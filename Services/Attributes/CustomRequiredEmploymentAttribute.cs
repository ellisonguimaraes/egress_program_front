using System.ComponentModel.DataAnnotations;

namespace EgressPortal.Services.Attributes;

public class CustomRequiredEmploymentAttribute : ValidationAttribute
{
    private const string REQUIRED_ERROR_MESSAGE = "Campo requerido"; 
    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var conditionalProperty = (CompleteRegisterForm)validationContext.ObjectInstance;
        
        if (!conditionalProperty.HaveJob)
            return ValidationResult.Success!;

        if (value is string str)
            if (!string.IsNullOrWhiteSpace(str)) 
                return ValidationResult.Success!;
        
        if (value is not null)
            return ValidationResult.Success!;
        
        return new ValidationResult(REQUIRED_ERROR_MESSAGE, new[] { validationContext.MemberName }!);
    }
}
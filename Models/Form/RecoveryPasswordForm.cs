using System.ComponentModel.DataAnnotations;

namespace EgressPortal.Models.Form;

public class RecoveryPasswordForm
{
    [Required(ErrorMessage = "Email é requerido")]
    [EmailAddress(ErrorMessage = "Formato incorreto de email")]
    public string Email { get; set; }
}
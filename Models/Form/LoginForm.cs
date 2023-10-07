using System.ComponentModel.DataAnnotations;

namespace EgressPortal.Models.Form;

public class LoginForm
{
    [Required(ErrorMessage = "Email é requerido.")]
    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres.")]
    [EmailAddress(ErrorMessage = "Formato incorreto de email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Senha é requerida")]
    [MinLength(8, ErrorMessage = "Mínimo de 8 caracteres")]
    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres.")]
    public string Password { get; set; }
}
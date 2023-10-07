using System.ComponentModel.DataAnnotations;

namespace EgressPortal.Models.Form;

public class RecoveryPasswordNewPasswordForm
{
    [Required(ErrorMessage = "Senha é requerido.")]
    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Repita a senha.")]
    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres.")]
    [Compare(nameof(Password), ErrorMessage = "Repita a mesma senha do campo acima")]
    public string RepeatPassword { get; set; }
}
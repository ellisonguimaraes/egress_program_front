using System.ComponentModel.DataAnnotations;
using EgressPortal.Models.Form.Enums;

namespace EgressPortal.Models.Form;

public class RegisterForm
{
    [Required(ErrorMessage = "Escolha entre egresso, docente ou discente.")]
    public UserType UserType { get; set; }

    [Required(ErrorMessage = "Nome é requerido.")]
    [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Escolha entre CPF ou Matrícula.")]
    public DocumentType DocumentType { get; set; } = DocumentType.Cpf;

    [Required(ErrorMessage = "Campo Documento é requerido.")]
    [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres.")]
    public string Document { get; set; }

    [Required(ErrorMessage = "Email é requerido.")]
    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres.")]
    [EmailAddress(ErrorMessage = "Formato incorreto de email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Senha é requerido.")]
    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Repita a senha.")]
    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres.")]
    [Compare(nameof(Password), ErrorMessage = "Repita a mesma senha do campo acima")]
    public string RepeatPassword { get; set; }
}
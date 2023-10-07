using System.ComponentModel.DataAnnotations;

namespace EgressPortal.Models.Form;

public class ContactForm
{
    [Required(ErrorMessage = "O campo Assunto é requerido")]
    [MaxLength(100, ErrorMessage = "Assunto deve ter no máximo 100 caracteres")]
    public string Subject { get; set; }

    [Required(ErrorMessage = "O campo Email é requerido")]
    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres.")]
    [EmailAddress(ErrorMessage = "Formato incorreto de email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Mensagem é requerido")]
    public string Message { get; set; }
}
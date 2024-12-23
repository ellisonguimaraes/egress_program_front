using System.ComponentModel.DataAnnotations;

namespace EgressPortal.Models.Form;

public class ContactForm
{
    [Required(ErrorMessage = "O campo Nome é requerido")]
    [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
    public string Name { get; set; }

    [MaxLength(20, ErrorMessage = "Telefone deve ter no máximo 20 caracteres")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "O campo Assunto é requerido")]
    [MaxLength(100, ErrorMessage = "Assunto deve ter no máximo 100 caracteres")]
    public string Subject { get; set; }

    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Mensagem é requerido")]
    public string Message { get; set; }
}
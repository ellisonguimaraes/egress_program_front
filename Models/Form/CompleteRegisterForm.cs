using System.ComponentModel.DataAnnotations;
using EgressPortal.Models.Form.Enums;
using Microsoft.AspNetCore.Components.Forms;

namespace EgressPortal;

public class CompleteRegisterForm
{
    [Required(ErrorMessage = "O campo Nome é requerido")]
    [MaxLength(200, ErrorMessage = "Nome deve ter no máximo 200 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo Cpf é requerido")]
    [MaxLength(14, ErrorMessage = "Cpf deve ter no máximo 11 caracteres")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "Data de nascimento é requerido")]
    public DateTime? BirthDate { get; set; }

    [Required(ErrorMessage = "Sexo é requerido")]
    public Sex Sex { get; set; }

    public IBrowserFile PerfilImage { get; set; }

    public CompleteRegisterAddressForm Address { get; set; }

    public CompleteRegisterContactForm Contact { get; set; }
    
    public IList<CompleteRegisterCourseForm> Courses { get; set; }

    public IList<CompleteRegisterEmploymentForm> Employments { get; set; }
}

public class CompleteRegisterAddressForm
{
    public int? Number { get; set; }

    [MaxLength(45, ErrorMessage = "Rua deve ter no máximo 45 caracteres")]
    public string Street { get; set; }

    [MaxLength(45, ErrorMessage = "Bairro deve ter no máximo 45 caracteres")]
    public string District { get; set; }

    [Required(ErrorMessage = "O campo Cidade é requerido")]
    [MaxLength(45, ErrorMessage = "Cidade deve ter no máximo 45 caracteres")]
    public string City { get; set; }

    [Required(ErrorMessage = "O campo Estado é requerido")]
    [MaxLength(45, ErrorMessage = "Estado deve ter no máximo 45 caracteres")]
    public string State { get; set; }

    [Required(ErrorMessage = "O campo País é requerido")]
    [MaxLength(45, ErrorMessage = "País deve ter no máximo 45 caracteres")]
    public string Country { get; set; }
}

public class CompleteRegisterContactForm
{
    
    [Required(ErrorMessage = "O campo Email é requerido")]
    [MaxLength(80, ErrorMessage = "Email deve ter no máximo 80 caracteres")]
    [EmailAddress(ErrorMessage = "Formato incorreto de email")]
    public string Email { get; set; }

    [MaxLength(45, ErrorMessage = "Celular deve ter no máximo 45 caracteres")]
    public string PhoneNumber { get; set; }
}

public class CompleteRegisterCourseForm
{
    [Required(ErrorMessage = "O campo Curso é requerido")]
    [MaxLength(100, ErrorMessage = "Curso deve ter no máximo 100 caracteres")]
    public string CourseName { get; set; }

    [Required(ErrorMessage = "O campo Instituição é requerido")]
    [MaxLength(100, ErrorMessage = "Instituição deve ter no máximo 100 caracteres")]
    public string InstitutionName { get; set; }

    [Required(ErrorMessage = "O campo Status é requerido")]
    public bool Status { get; set; }

    [Required(ErrorMessage = "O campo Modalidade é requerido")]
    public Modality Modality { get; set; }

    [Required(ErrorMessage = "O campo Tipo é requerido")]
    public Level Level { get; set; }

    [Required(ErrorMessage = "O campo Data de Início é requerido")]
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}

public class CompleteRegisterEmploymentForm
{
    [Required(ErrorMessage = "O campo Empresa é requerido")]
    [MaxLength(80, ErrorMessage = "Empresa deve ter no máximo 80 caracteres")]
    public string EnterpriseName { get; set; }

    [Required(ErrorMessage = "O campo Cargo é requerido")]
    [MaxLength(150, ErrorMessage = "Cargo deve ter no máximo 150 caracteres")]
    public string Role { get; set; }

    [Required(ErrorMessage = "O campo Setor é requerido")]
    [MaxLength(45, ErrorMessage = "Setor deve ter no máximo 45 caracteres")]
    public string Section { get; set; }

    [Required(ErrorMessage = "O campo Status é requerido")]
    public bool IsCurrent { get; set; }

    public double? SalaryRange { get; set; }

    [Required(ErrorMessage = "O campo Iniciativa é requerido")]
    public bool IsPublicInitiative { get; set; }

    [Required(ErrorMessage = "O campo Data de Início é requerido")]
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}

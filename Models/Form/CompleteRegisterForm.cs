﻿using System.ComponentModel.DataAnnotations;
using EgressPortal.Services.Attributes;
using Microsoft.AspNetCore.Components.Forms;

namespace EgressPortal;

public class CompleteRegisterForm
{
    [Required(ErrorMessage = "Campo requerido")]
    public DateTime? BirthDate { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [MaxLength(45, ErrorMessage = "Máximo de 45 caracteres")]
    [RegularExpression(@"\(\d{2}\)\s\d\s\d{4}-\d{4}", ErrorMessage = "Formato inválido, tente o formato (00) 0 0000-0000.")]
    public string PhoneNumber { get; set; }
    
    public bool CanExposeData { get; set; } = false;
    
    public bool CanReceivedMessage { get; set; } = false;

    public IBrowserFile PerfilImage { get; set; } = null!;
    
    #region ContinuingEducation Properties
    [Required(ErrorMessage = "Campo requerido")]
    public bool? HasCertification { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    public bool? HasSpecialization { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    public bool? HasMasterDegree { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    public bool? HasDoctorateDegree { get; set; }

    public bool IsContinuingEducationPublic { get; set; } = false;
    #endregion
    
    #region Address Properties
    [Required(ErrorMessage = "Campo requerido")]
    [MaxLength(45, ErrorMessage = "Máximo de 45 caracteres")]
    public string State { get; set; }
    
    [Required(ErrorMessage = "Campo requerido")]
    [MaxLength(45, ErrorMessage = "Máximo de 45 caracteres")]
    public string Country { get; set; }

    public bool IsAddressPublic { get; set; } = false;
    #endregion
    
    #region Employment Properties
    public bool HaveJob { get; set; }
    
    [CustomRequiredEmployment]
    public string EnterpriseName { get; set; }

    [CustomRequiredEmployment]
    public string Role { get; set; }

    [CustomRequiredEmployment]
    public bool IsPublicInitiative { get; set; } = false;

    [CustomRequiredEmployment]
    public DateTime? StartDate { get; set; }
    
    public double? SalaryRange { get; set; }
    
    [CustomRequiredEmployment]
    public bool IsEmploymentPublic { get; set; } = false;
    #endregion
}
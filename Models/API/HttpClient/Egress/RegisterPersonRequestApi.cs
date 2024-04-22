using Refit;
using EgressPortal.Models.Form.Enums;

namespace EgressPortal;

public class RegisterPersonRequestApi
{
    [AliasAs("cpf")]
    public string Cpf { get; set; }

    [AliasAs("name")]
    public string Name { get; set; }

    [AliasAs("birth_date")]
    public DateTime? BirthDate { get; set; }

    [AliasAs("sex")]
    public Sex? Sex { get; set; }

    [AliasAs("email")]
    public string? Email { get; set; }

    [AliasAs("phone_number")]
    public string? PhoneNumber { get; set; }

    [AliasAs("perfil_image")]
    public StreamPart? PerfilImage { get; set; }

    #region Authentication Properties
    [AliasAs("person_type")]
    public PersonType? PersonType { get; set; }
    #endregion

    [AliasAs("address")]
    public virtual RegisterPersonAddressRequestApi? Address { get; set; }
    
    [AliasAs("courses")]
    public List<RegisterPersonCourseRequestApi>? Courses { get; set; }
    
    [AliasAs("specializations")]
    public List<RegisterPersonSpecializationRequestApi>? Specializations { get; set; }

    [AliasAs("employment")]
    public RegisterPersonEmploymentRequestApi Employment { get; set; }
}


public class RegisterPersonSpecializationRequestApi
{
    [AliasAs("course_name")]
    public string CourseName { get; set; }

    [AliasAs("institution")]
    public string InstitutionName { get; set; }

    [AliasAs("is_studying")]
    public bool? Status { get; set; }

    [AliasAs("type")]
    public Level? Type { get; set; }

    [AliasAs("modality")]
    public Modality? Modality { get; set; }

    [AliasAs("start_date")]
    public DateTime StartDate { get; set; }

    [AliasAs("end_date")]
    public DateTime? EndDate { get; set; }
}

public class RegisterPersonEmploymentRequestApi
{
    [AliasAs("role")]
    public string Role { get; set; }

    [AliasAs("enterprise")]
    public string Enterprise { get; set; }

    [AliasAs("section")]
    public string Section { get; set; }

    [AliasAs("salary_range")]
    public decimal? SalaryRange { get; set; }

    [AliasAs("is_public_initiative")]
    public bool IsPublicInitiative { get; set; }

    [AliasAs("is_current")]
    public bool? Status { get; set; }

    [AliasAs("start_date")]
    public DateTime? StartDate { get; set; }

    [AliasAs("end_date")]
    public DateTime? EndDate { get; set; }
}

public class RegisterPersonAddressRequestApi
{
    [AliasAs("number")]
    public long? Number { get; set; }

    [AliasAs("street")]
    public string? Street { get; set; }

    [AliasAs("district")]
    public string? District { get; set; }

    [AliasAs("city")]
    public string City { get; set; }

    [AliasAs("state")]
    public string State { get; set; }

    [AliasAs("country")]
    public string Country { get; set; }
}

public class RegisterPersonCourseRequestApi
{
    [AliasAs("course_id")]
    public Guid? CourseId { get; set; }

    [AliasAs("beginning_semester")]
    public string? BeginningSemester { get; set; }

    [AliasAs("final_semester")]
    public string? FinalSemester { get; set; }

    [AliasAs("mat")]
    public string Mat { get; set; }

    [AliasAs("level")]
    public Level? Level { get; set; }
    
    [AliasAs("modality")]
    public Modality? Modality { get; set; }
}
using System.Text.Json.Serialization;

namespace EgressPortal.Models.API.HttpClient.Admin;

public class CreatePersonRequestApi
{
    [JsonPropertyName("cpf")]
    public string Cpf { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("birth_date")]
    public DateTime BirthDate { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("can_expose_data")]
    public bool CanExposeData { get; set; }

    [JsonPropertyName("can_receive_message")]
    public bool CanReceiveMessage { get; set; }

    [JsonPropertyName("person_type")]
    public int PersonType { get; set; }

    [JsonPropertyName("course")]
    public Course Course { get; set; }
}

public class Course
{
    [JsonPropertyName("course_id")]
    public string CourseId { get; set; }

    [JsonPropertyName("beginning_semester")]
    public string BeginningSemester { get; set; }

    [JsonPropertyName("final_semester")]
    public string FinalSemester { get; set; }

    [JsonPropertyName("mat")]
    public string Mat { get; set; }

    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("modality")]
    public int Modality { get; set; }
}
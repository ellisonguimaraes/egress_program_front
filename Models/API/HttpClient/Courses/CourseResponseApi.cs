using System.Text.Json.Serialization;
using EgressPortal.Models.Form.Enums;

namespace EgressPortal.Models.API.HttpClient.Courses;

public class CourseResponseApi
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("course_name")]
    public string CourseName { get; set; }

    [JsonPropertyName("beginning_semester")]
    public string BeginningSemester { get; set; }

    [JsonPropertyName("final_semester")]
    public string FinalSemester { get; set; }

    [JsonPropertyName("mat")]
    public string Mat { get; set; }

    [JsonPropertyName("level")]
    public Level Level { get; set; }

    [JsonPropertyName("modality ")]
    public Modality Modality { get; set; }
}
using System.Text.Json.Serialization;

namespace EgressPortal.Models.API.HttpClient.Egress.Course;

public class CourseResponseApi
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("course_name")]
    public string? CourseName { get; set; }
    
    [JsonPropertyName("normalized_course_name")]
    public string? NormalizedCourseName { get; set; }
}
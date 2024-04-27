using EgressPortal.Models.Form.Enums;

namespace EgressPortal.Models.Form;

public class EgressFilterForm
{
    public string EgressName { get; set; }
    
    public string CourseName { get; set; }

    public string Subscription { get; set; }

    public bool CheckModalityClassroom { get; set; }

    public bool CheckModalityHybrid { get; set; }

    public bool CheckModalityVirtualClass { get; set; }

    public bool CheckLevelGraduation { get; set; }

    public bool CheckLevelPostgraduate { get; set; }

    public bool CheckLevelMasterDegree { get; set; }

    public bool CheckLevelDoctorateDegree { get; set; }

    public string BeginningSemester { get; set; }
    
    public string FinalSemester { get; set; }
}
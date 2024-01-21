namespace HCI.Server.Dto;

public class VisitDto
{
    public int Id { get; set; }
    public DateTime VisitedOn { get; set; }
    public string PatientName { get; set; }
    public string HospitalName { get; set; }
    public string DoctorName { get; set; }
}

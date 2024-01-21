namespace HCI.Server.Dto;

public class VisitDto
{
    public int Id { get; set; }
    public int HospitalId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }


    public DateTime Date { get; set; }
    public string PatientName { get; set; }
    public string HospitalName { get; set; }
    public string DoctorName { get; set; }


    public string Description { get; set; }
    public string Diagnosis { get; set; }
    public string Therapy { get; set; }
    public string Notes { get; set; }
    public string Medications { get; set; }
    public string Tests { get; set; }
    public string Recommendations { get; set; }
}

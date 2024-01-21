using System.ComponentModel.DataAnnotations.Schema;

namespace HCI.Server.Database.Models;

public class Visit
{
    [DatabaseGenerated( DatabaseGeneratedOption.None )]
    public required int Id { get; set; }

    // patient
    public required int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    // hospital
    public required int HospitalId { get; set; }
    public Hospital Hospital { get; set; } = null!;

    // doctor
    public required int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;

    public DateTime VisitedOn { get; set; }
}

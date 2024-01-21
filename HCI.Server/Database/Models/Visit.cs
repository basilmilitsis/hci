using System.ComponentModel.DataAnnotations.Schema;

namespace HCI.Server.Database.Models;

public class Visit
{
    [DatabaseGenerated( DatabaseGeneratedOption.None )]
    public required int Id { get; set; }

    public required int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    public required int HospitalId { get; set; }
    public Hospital Hospital { get; set; } = null!;
}

using System.ComponentModel.DataAnnotations.Schema;

namespace HCI.Server.Database.Models;

public class Hospital
{
    [DatabaseGenerated( DatabaseGeneratedOption.None )]
    public required int Id { get; set; }
    public required string Name { get; set; }

    public IList<Visit> Visits { get; } = new List<Visit>();
}

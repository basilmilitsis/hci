using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCI.Server.Database.Models;

public class Doctor
{
    [DatabaseGenerated( DatabaseGeneratedOption.None )]
    public required int Id { get; set; }
    public required string Name { get; set; }
}

using HCI.Server.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace HCI.Server.Database;

public class HciDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<Doctor> Doctors { get; set; }

    public HciDbContext ( DbContextOptions<HciDbContext> options ) : base( options )
    {
    }
}

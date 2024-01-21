using HCI.Server.Database.Models;
using System.Numerics;

namespace HCI.Server.Database.Initialiser;

public static class DbInitialiser
{
    public static void CreateDbDataIfEmpty ( IHost host )
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<HciDbContext>();
                DbInitialiser.Initialize( context );
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError( ex, "An error occurred creating the DB." );
            }
        }
    }

    private static void Initialize ( HciDbContext context )
    {
        context.Database.EnsureCreated();

        if (context.Patients.Any())
        {
            return;   // DB has been seeded
        }

        // Add Patients
        var patients = new Patient[]
            {
            new Patient{Id=1,Name="Bob Builder",Email="bob@builder.com"},
            new Patient{Id=2,Name="Mary Maker",Email="mary@yahoo.com"},
            new Patient{Id=3,Name="Joe Soap",Email="joe@apple.com"},
            };
        foreach (Patient patient in patients)
        {
            context.Patients.Add( patient );
        }
        context.SaveChanges();

        // Add Hospitals
        var hospitals = new Hospital[]
            {
            new Hospital{Id=1,Name="Bantry General Hospital"},
            new Hospital{Id=2,Name="Cork University Hospital"},
            new Hospital{Id=3,Name="Dental University Hospital"},
            };
        foreach (Hospital hospital in hospitals)
        {
            context.Hospitals.Add( hospital );
        }
        context.SaveChanges();

        // Add Doctors
        var doctors = new Doctor[]
            {
            new Doctor{Id=1,Name="Dr. Gregory House"},
            new Doctor{Id=2,Name="Dr. Who"},
            new Doctor{Id=3,Name="Dr. Patch Adams"},
            };
        foreach (Doctor doctor in doctors)
        {
            context.Doctors.Add( doctor );
        }
        context.SaveChanges();

        // Add Visits
        var visits = new Visit[]
            {
            new Visit{
                Id=1, 
                PatientId=1, 
                HospitalId=1, 
                DoctorId=1, 
                VisitedOn=DateTime.UtcNow.AddDays(-10), 
            },
            new Visit{
                Id=2, 
                PatientId=2, 
                HospitalId=2, 
                DoctorId=2, 
                VisitedOn=DateTime.UtcNow.AddDays(-20), 
            },
            new Visit{
                Id=3, 
                PatientId=3, 
                HospitalId=3, 
                DoctorId=3, 
                VisitedOn=DateTime.UtcNow.AddDays(-30), 
            },
        };
        foreach (Visit visit in visits)
        {
            context.Visits.Add( visit );
        }
        context.SaveChanges();
    }
}

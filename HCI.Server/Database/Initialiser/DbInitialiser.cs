using HCI.Server.Database.Models;

namespace HCI.Server.Database.Initialiser;

public static class DbInitialiser
{

    public static void Initialize ( HciDbContext context )
    {
        context.Database.EnsureCreated();

        if (context.Patients.Any())
        {
            return;   // DB has been seeded
        }

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



        var visits = new Visit[]
            {
            new Visit{Id=1,PatientId=1,HospitalId=1},
            new Visit{Id=2,PatientId=2,HospitalId=2},
            new Visit{Id=3,PatientId=3,HospitalId=3},
            };
        foreach (Visit visit in visits)
        {
            context.Visits.Add( visit );
        }
        context.SaveChanges();
    }
}

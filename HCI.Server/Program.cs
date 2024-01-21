using HCI.Server.Database;
using HCI.Server.Database.Initialiser;
using HCI.Server.Dto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HciDbContext>( options =>
    options.UseSqlServer( builder.Configuration.GetConnectionString( "DefaultConnection" ) ) );
builder.Services.AddHttpLogging( o => { } );
builder.Logging.AddConsole();

// Build the app.
var app = builder.Build();
app.UseHttpLogging();
app.UseDefaultFiles();
app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile( "/index.html" );
app.UseCors( options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader() ); // TODO: tighten up for production

// Initialise DB data if not already done
DbInitialiser.CreateDbDataIfEmpty( app );

// Api - would not normally have this dorectly in program.cs
app.MapGet( "api/visits/search", async ( string searchPatientName, string searchHospitalName, HciDbContext dbContext ) =>
{
    var visits = dbContext.Visits.Where( visit => visit.Patient.Name.Contains( searchPatientName ) && visit.Hospital.Name.Contains( searchHospitalName ) );

    // map visits to dto
    var visitDtos = visits.Select( visit => new VisitDto
    {
        Id = visit.Id,
        VisitedOn = visit.VisitedOn,
        PatientName = visit.Patient.Name,
        HospitalName = visit.Hospital.Name,
        DoctorName = visit.Doctor.Name,
    } );

    var response = new VisitResponse { Visits = await visitDtos.ToArrayAsync() };
    return response;
} );

// Run the app.
app.Run();
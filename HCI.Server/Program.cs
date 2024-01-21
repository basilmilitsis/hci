using HCI.Server.Database;
using HCI.Server.Database.Initialiser;
using HCI.Server.Dto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
app.MapFallbackToFile("/index.html");

app.UseCors( options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader() ); // TODO

// Initialise DB content if not already done
CreateDbIfNotExists( app );

app.MapGet( "api/visits/search", async ( string searchText, HciDbContext dbContext ) => {
    //ILogger logger
    //logger.LogInformation( "=================> Searching visits" );

    var visits = dbContext.Visits.Where( v => v.Patient.Name.Contains( searchText ) );

    // map visits to dto
    var visitDtos = visits.Select( v => new VisitDto
    {
        Id = v.Id,
        HospitalId = v.HospitalId,
        HospitalName = v.Hospital.Name,
        DoctorId = 1,//v.DoctorId,
        DoctorName = "",//v.Doctor.Name,
        PatientId = v.PatientId,
        PatientName = v.Patient.Name,
        Date = DateTime.Now,//v.Date,

        Description = "",//v.Description,
        Diagnosis = "",//.Diagnosis,
        Medications = "",//v.Medications,
        Notes = "",//v.Notes,
        Recommendations = "",//v.Recommendations,
        Tests = "",//v.Tests,
        Therapy = "",//v.Therapy
    } );

    var response = new VisitResponse { Visits = await visitDtos.ToArrayAsync() };
    return response;
} );


// Run the app.
app.Run();






static void CreateDbIfNotExists ( IHost host )
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



//wa-hci-api-admin

//6PD54M4JSD30WZD4$
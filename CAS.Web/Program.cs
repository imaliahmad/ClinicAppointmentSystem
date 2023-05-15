using CAS.BLL;
using CAS.DAL;
using CAS.DAL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region DALRegion
builder.Services.AddTransient<IDoctorsDb, DoctorsDb>();
builder.Services.AddTransient<IPatientsDb, PatientsDb>();
#endregion

#region BLLRegion
builder.Services.AddTransient<IDoctorsBs, DoctorsBs>();
builder.Services.AddTransient<IPatientsBs, PatientsBs>();
#endregion

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(@"Server=MEHROZQAZI-PC\SQLEXPRESS;Database=ClinicAppointmentSystem;Trusted_Connection=True"));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}"
    );
app.Run();

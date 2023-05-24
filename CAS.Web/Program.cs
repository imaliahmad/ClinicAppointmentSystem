using CAS.BLL;
using CAS.DAL;
using CAS.DAL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region DALRegion
builder.Services.AddTransient<IDoctorsDb, DoctorsDb>();
builder.Services.AddTransient<IPatientsDb, PatientsDb>();
builder.Services.AddTransient<IAppointmentsDb, AppointmentsDb>();
#endregion

#region BLLRegion
builder.Services.AddTransient<IDoctorsBs, DoctorsBs>();
builder.Services.AddTransient<IPatientsBs, PatientsBs>();
builder.Services.AddTransient<IAppointmentsBs, AppointmentsBs>();
#endregion

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(@"Server=MEHROZQAZI-PC\SQLEXPRESS;Database=ClinicAppointmentSystemF;Trusted_Connection=True"));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}"
    );
app.Run();

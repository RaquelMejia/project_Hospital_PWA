using HospitalProject.Data;
using HospitalProject.Repositories.Doctor;
using HospitalProject.Repositories.DoctorSpecialty;
using HospitalProject.Repositories.Patients;
using HospitalProject.Repositories.Room;
using HospitalProject.Repositories.RoomsRegisters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<IDoctorSpecialtyRepository, DoctorSpecialtyRepositories>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IRoomsRepository, RoomsRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IRoomsRegistersRepository, RoomsRegistersRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

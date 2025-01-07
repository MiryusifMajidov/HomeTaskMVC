using HospitalMApi.Bl.Implementations.Interfaces;
using HospitalMApi.Bl.Implementations.Services;
using HospitalMApi.Dal.DAL;
using HospitalMApi.Dal.Implementations.Repositories;
using HospitalMApi.Dal.Implementations.RepositoryIntefaces;
using HospitalMApi.Model.MappingProfile;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IInsuranceService, InsuranceService >();
builder.Services.AddScoped<IPatientService, PatientService >();
builder.Services.AddAutoMapper(typeof(InsuranceProfile));
builder.Services.AddAutoMapper(typeof(PatientProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Veterinary.Data;
using Veterinary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Service to mapping program
builder.Services.AddControllers();

//Connection db
builder.Services.AddDbContext<DataContext>(options=>{
    options.UseMySql(builder.Configuration.GetConnectionString("MyConnection"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.2-Mysql"),
    options => options.EnableRetryOnFailure());
});

//Interfaz & Repository
builder.Services.AddScoped<IVetsRepository, VetsRepository>();
builder.Services.AddScoped<IOwnersRepository, OwnersRepository>();
builder.Services.AddScoped<IPetsRepository, PetsRepository>();
builder.Services.AddScoped<IQuotesRepository, QuotesRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Mapping controllers
app.MapControllers();

app.Run();


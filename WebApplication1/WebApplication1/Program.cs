using Microsoft.EntityFrameworkCore;
using WebApplication1.Infrastructure;
using WebApplication1.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//dodaj asocjację pomiędzy servisem klasy i klasą
builder.Services.AddScoped<IPCService, PCService>();

builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    //"default" jest referencją do zmiennej do connection stringa
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    //dodać jeżeli są błędy w migracji -- supresuje je
    opt.ConfigureWarnings(w =>
        w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //dodać aby działał swagger
    app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/openapi/v1.json", "WebApplication1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
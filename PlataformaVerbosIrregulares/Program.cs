using PlataformaVerbosIrregulares.Models.Entities;
using PlataformaVerbosIrregulares.Repositories;
using PlataformaVerbosIrregulares.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<VerbosdbContext>();
builder.Services.AddScoped(typeof(Repository<>));
builder.Services.AddScoped<VerbosService>();
builder.Services.AddScoped<OracionesService>();
builder.Services.AddScoped<EstructurasGramaticalesService>();

var app = builder.Build();



app.UseFileServer();
app.MapControllers();

app.Run();

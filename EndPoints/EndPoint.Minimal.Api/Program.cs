using EndPoint.Minimal.Api.Data;
using EndPoint.Minimal.Api.EndPoints;
using EndPoint.Minimal.Api.Services.GenreServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
builder.Services.AddScoped<IGenreService, GenreService>();
var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

GenreEndpoints.MapEndpoints(app);


app.Run();

using EndPoint.Minimal.Api.Data;
using EndPoint.Minimal.Api.EndPoints;
using EndPoint.Minimal.Api.Services.GenreServices;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(policy => policy.Expire(TimeSpan.FromMinutes(10)));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
builder.Services.AddScoped<IGenreService, GenreService>();
var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference(options =>
    {
        options.WithTheme(ScalarTheme.Purple);
    });
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "Minimal API Movies ";
    });
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseOutputCache();
GenreEndpoints.MapEndpoints(app);


app.Run();

using System.Text.Json;
using EndPoint.Minimal.Api.Data;
using EndPoint.Minimal.Api.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        config.WithOrigins("").AllowAnyOrigin().AllowAnyOrigin();

    });
    options.AddPolicy("Free", config =>
    {
        config.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });

});
builder.Services.AddOutputCache();
var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//app.MapGet("/genres", [EnableCors(policyName: "Free")] () =>
//{

//    var genre = new List<Genre>()
//    {
//        new ("Action", "Action Video Category"),
//        new ("Sport", "Sport Video Category"),

//    };

//    var result = genre.All(c => c.Name == "Sport");
//    return genre;

//}).CacheOutput(c => c.Expire(TimeSpan.FromSeconds(15)));
app.UseOutputCache();
app.UseCors();
app.Run();

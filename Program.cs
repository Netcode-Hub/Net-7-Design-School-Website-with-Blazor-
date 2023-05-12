using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using SchoolApp.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Personal Setup / Codem High School
//Connection
builder.Services.AddDbContext<AppDbContext>(Options =>
{
    Options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //link the projects together: client, api
    app.UseCors(policy =>
    {
        policy.WithOrigins("http://localhost:7289", "https://localhost:7289") //do not add the forward slash at end
        .AllowAnyMethod()
        .WithHeaders(HeaderNames.ContentType);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

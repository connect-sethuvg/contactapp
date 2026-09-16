
using ContactPage.Business;
using ContactPage.DTO.Mappers;
using Microsoft.EntityFrameworkCore;
using RI.ContactPage.Data;
using ContactPage.Data;
using ContactPage.DataService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

string? connString = builder.Configuration.GetConnectionString("ContactPage");
builder.Services.AddDbContext<DbContext, ContactPageContext>(option=> option.UseSqlServer(connString));


builder.Services.AddEntities();
builder.Services.Addservice();
builder.Services.AddDTOMapper();
builder.Services.AddDataService();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var contect = scope.ServiceProvider.GetRequiredService<ContactPageContext>();
    contect.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

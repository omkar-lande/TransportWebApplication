

using MediatR;
using Ardalis.ApiEndpoints;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TransportModel.Commands;
using TransportModel.Data;
using TransportModel.Handlers;
using TransportModel.Model;
using TransportModel.Queries;
using Microsoft.OpenApi.Models;
using TransportWebApplication.Controllers;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


 builder.Services.AddMvc();
 builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"), b => b.MigrationsAssembly("TransportModel")));
 builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TransportWebApplication", Version = "1.0" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath); // This line includes the XML comments in Swagger
});

builder.Services.AddMediatR(Assembly.GetAssembly(typeof(AddTransporterToInstructionProductCommandHandler)));
builder.Services.AddMediatR(Assembly.GetAssembly(typeof(CreateInstrucionCommand)));
builder.Services.AddScoped<IRequestHandler<CreateInstrucionCommand, int>, CreateInstructionCommandHandler>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IInstructionDataAcess, InstructionDataAcess>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

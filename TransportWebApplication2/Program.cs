/* using MediatR;
using Ardalis.ApiEndpoints;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TransportModel.Commands;
using TransportModel.Data;
using TransportModel.Handlers;
using TransportModel.Model;
using TransportModel.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"), b => b.MigrationsAssembly("TransportModel")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IRequestHandler<CreateInstrucionCommand, int>, CreateInstructionCommandHandler>();
builder.Services.AddMediatR(Assembly.GetAssembly(typeof(CreateInstrucionCommand)));
builder.Services.AddEndpointsCore();
builder.Services.AddTransient<IRequestHandler<FilterClientsQuery, List<ClientDto>>, FilterClientsQueryHandler>();

//builder.Services.AddScoped<IInstructionDataAcess, InstructionDataAcess>();
//builder.Services.AddMediatR(Assembly.GetAssembly(typeof(CreateInstrucionCommand)));
//builder.Services.AddMediatR(Assembly.GetAssembly(typeof(CreateInstrucionCommand)), Assembly.GetAssembly(typeof(GetAllnstructionsQueryHandler)));


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
*/

/*
using MediatR;
using TransportModel.Data;
using TransportModel.Model;
using TransportModel.Queries;

public class FilterClientsQueryHandler : IRequestHandler<FilterClientsQuery, List<ClientDto>>
{
    private readonly ApplicationDbContext _dbContext;

    public FilterClientsQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ClientDto>> Handle(FilterClientsQuery request, CancellationToken cancellationToken)
    {
        var filteredClients = await _dbContext.ClientLists
            .Where(client => client.ClientName.Contains(request.FilterText))
            .Select(client => new ClientDto
            {
                Id = client.ClientId,
                Name = client.ClientName
            })
            .ToListAsync(cancellationToken); // Use ToListAsync on the IQueryable of Clients, not ClientDto

        return filteredClients;
    }
}

*/






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
using TransportWebApplication2.Controllers;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 builder.Services.AddMvc();
 builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"), b => b.MigrationsAssembly("TransportModel")));
//builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("MyWebApiConection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TransportWebApplication", Version = "1.0" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath); // This line includes the XML comments in Swagger
});
//builder.Services.AddScoped<IRequestHandler<CreateInstrucionCommand, int>, createInstruction>();

builder.Services.AddMediatR(Assembly.GetAssembly(typeof(AddTransporterToInstructionProductCommandHandler)));
//builder.Services.AddScoped<IRequestHandler<AddTransporterToInstructionProductCommand, bool>, UpdateTransporterToInstructionProductCommand>();

//builder.Services.AddScoped<IRequestHandler<AddTransporterToInstructionProductCommand, bool>, >();
builder.Services.AddMediatR(Assembly.GetAssembly(typeof(CreateInstrucionCommand)));
builder.Services.AddScoped<IRequestHandler<CreateInstrucionCommand, int>, CreateInstructionCommandHandler>();
builder.Services.AddEndpointsApiExplorer();



//builder.Services.AddTransient<IRequestHandler<FilterClientsQuery, List<ClientDto>>, FilterClientsQueryHandler>();
builder.Services.AddScoped<IInstructionDataAcess, InstructionDataAcess>();
//builder.Services.AddMediatR(Assembly.GetAssembly(typeof(CreateInstrucionCommand)));
//builder.Services.AddMediatR(Assembly.GetAssembly(typeof(CreateInstrucionCommand)), Assembly.GetAssembly(typeof(GetAllnstructionsQueryHandler)));


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

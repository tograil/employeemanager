using EmployeeManagement.Api.Map;
using EmployeeManagement.Core.Contracts;
using EmployeeManagement.Core.Enums;
using EmployeeManagement.Infrastructure.Context;
using EmployeeManagement.Infrastructure.Services;
using JsonSubTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EmployeeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IEmployeesService, EmployeeService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(JsonSubtypesConverterBuilder.
            Of(typeof(PersonModel), "personType")
            .RegisterSubtype(typeof(SupervisorModel), PersonType.Supervisor.ToString())
            .RegisterSubtype(typeof(EmployeeModel), PersonType.Employee.ToString())
            .RegisterSubtype(typeof(ManagerModel), PersonType.Manager.ToString())
            .SerializeDiscriminatorProperty()
            .Build());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "PolymorphismInWebApi",
            Version = "v1"
        }
    );
    c.UseAllOfToExtendReferenceSchemas();
    c.UseAllOfForInheritance();
    c.UseOneOfForPolymorphism();
    c.SelectDiscriminatorNameUsing(type =>
    {
        return type.Name switch
        {
            nameof(PersonModel) => "personType",
            _ => null
        };
    });
});

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

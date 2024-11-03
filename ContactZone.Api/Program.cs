using ContactZone.Application.Repositories;
using ContactZone.Infrastructure.Repositories;
using ContactZone.Application.Services;
using ContactZone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
RegisterGeneralServices(builder);
RegisterScoped(builder);
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

void RegisterScoped(WebApplicationBuilder builder)
{
    builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    builder.Services.AddScoped<IContactRepository, ContactRepository>();
    builder.Services.AddScoped<IContactService, ContactService>();
}

void RegisterGeneralServices(WebApplicationBuilder builder)
{
    // Add services to the container.
    builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

    // Add FluentValidation services
    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddFluentValidationClientsideAdapters();
    builder.Services.AddValidatorsFromAssemblyContaining<Program>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Configure DbContext with connection string and specify migrations assembly
    builder.Services.AddDbContext<ContactZoneDbContext>(options =>
        options.UseSqlServer(
        builder.Configuration.GetConnectionString("ContactZone"),
        b => b.MigrationsAssembly("ContactZone.Infrastructure"))
        ,ServiceLifetime.Scoped);
}
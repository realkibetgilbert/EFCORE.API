using EFCORE.API.Dtos;
using EFCORE.API.Helpers.FluentValidation;
using EFCORE.API.Helpers.ObjectMapping;
using EFCORE.Infrastructure;
using EFCORE.Infrastructure.Migrations;
using EFCORE.Infrastructure.Sqlserverimplementations;
using EFCOREAPI.CORE.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Registering InMemory Cache
builder.Services.AddMemoryCache();
#endregion
#region Registering Services
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IValidator<StudentToCreateDto>, StudentRegistrationValidator>();

builder.Services.AddDbContextPool<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EfCoreConnectionString")));
builder.Services.AddControllers()
     .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling =
      Newtonsoft.Json.ReferenceLoopHandling.Ignore);


builder.Services.AddScoped<IStudentService, StudentService>();
#endregion

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

    dbContext.Database.Migrate();
}

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

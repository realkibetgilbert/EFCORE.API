using EFCORE.API.Helpers;
using EFCORE.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Registering Services
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContextPool<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EfCoreConnectionString")));
builder.Services.AddControllers()
     .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling =
      Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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

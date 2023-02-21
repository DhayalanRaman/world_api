using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using World.Api.AutoMapper;
using World.Api.Data;
using World.Api.Repository;
using World.Api.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CustomPolicy", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
#endregion

#region Configure DataBase
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
#endregion

#region Configure Auto Mapping
builder.Services.AddAutoMapper(typeof(MappingProfile));
#endregion

#region Configure Dependency Injection from Constructor
builder.Services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<IStateRepository, StateRepository>();
#endregion

#region Configure SeriLog
//builder.Host.UseSerilog((context, config) =>
//{
//    ConfiguredTaskAwaitable.WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day);

//    if (context.HostingEnvironment.IsProduction() == false)
//    {
//        config.WriteTo.Console()
//    }
//});
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CustomPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

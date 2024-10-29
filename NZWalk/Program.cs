using Microsoft.EntityFrameworkCore;
using NZWalk.Data;
using NZWalk.Mappings;
using NZWalk.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();

builder.Services.AddDbContext<NZWalksDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("NZWalksConnectionString"),
        new MySqlServerVersion(new Version(8, 3, 0))  // Specify your MySQL version here
    )
);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

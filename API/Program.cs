// The entry point of the application:

using API.Data;
using API.Mappings;
using API.Repositories;
using Microsoft.EntityFrameworkCore;

// Create a builder for the web application:
var builder = WebApplication.CreateBuilder(args);

// Add services to the container (Inject services to the builder object):
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
// خطوط مربوط به AddOpenApi() و MapOpenApi() را حذف کن مگر اینکه از کتابخانه خاصی استفاده می کنی
// Inject DbContext class:
builder.Services.AddDbContext<IranWalksDbContext>(options => 
options.UseSqlServer(builder.Configuration
.GetConnectionString("IranWalksConnectionString")));
// Injects the Region repository with the implementation SQL region repository: 
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
// Injects Auto-mapper:
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
// Build the app:
var app = builder.Build();

// Configure the HTTP request pipeline (set middlewares):
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.MapOpenApi();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Run the app:
app.Run();

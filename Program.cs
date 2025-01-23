using Microsoft.EntityFrameworkCore;
using UkasNøttBackend;
using UkasNøttBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("*") // Allow the specific origin
              .AllowAnyHeader()                     // Allow any header
              .AllowAnyMethod();                     // Allow any HTTP method (including DELETE)
    });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<StudentDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<StudentService>();
var app = builder.Build();
// Enable CORS middleware
app.UseCors("AllowSpecificOrigin");

app.UseRouting();
using (var scope = app.Services.CreateScope())
{
    var studentService = scope.ServiceProvider.GetRequiredService<StudentService>();
    // StudentService constructor will automatically handle initialization
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





/* nuget console commands
 * sqllocaldb create local  -  i CMD vindu først.
 * Lage database:
 * Add-Migration InitialMigration
 * Update-Database
 * 
 * Rense:
 * Drop-Database 
 * Remove-Migration 
 */


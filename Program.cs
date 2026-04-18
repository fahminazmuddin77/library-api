using LibraryAPI.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ================== SERVICES ==================

// Controller
builder.Services.AddControllers();

// Database (Dependency Injection)
builder.Services.AddSingleton<DbContext>();

// Swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Library API",
        Version = "v1",
        Description = "REST API untuk manajemen buku"
    });
});

// ================== BUILD ==================

var app = builder.Build();

// ================== MIDDLEWARE ==================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API V1");
        options.RoutePrefix = "swagger"; 
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapping Controller
app.MapControllers();

app.Run();
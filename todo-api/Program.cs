using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using todo_data.Context;
using todo_data.Repository;
using todo_services;

var builder = WebApplication.CreateBuilder(args);

//builder.AddAppSettings();
builder.Services.AddDbContext<TodoDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString"), b => b.MigrationsAssembly("todo-data"))
);
builder.Services.AddScoped<DbContext, TodoDbContext>();

// Add services to the container.
builder.Services.AddDataServices(); 
builder.Services.AddBaseRepository();
builder.Services.AddBaseService();
builder.Services.AddControllers(options =>
{
    // Use JSON property names in validation errors
    options.ModelMetadataDetailsProviders.Add(new SystemTextJsonValidationMetadataProvider());
});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(cors =>
    {
        cors.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddSingleton(new MemoryCache(new MemoryCacheOptions
{
    SizeLimit = 256
}));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();
app.UseCors();
app.MapControllers();

// ef migrations
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TodoDbContext>();
    if (context.Database.GetPendingMigrations().Any())
        context.Database.Migrate();
}

// Start the application
app.Run();
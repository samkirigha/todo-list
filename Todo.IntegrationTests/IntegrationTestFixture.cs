using Todo.Models;
using todo_data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Todo.IntegrationTests;

public class IntegrationTestFixture<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    public readonly List<Item> Items = new List<Item>
    {
        new Item 
        { 
            Id = Guid.NewGuid(),
            Name = "Item one",
            Description = "This is item one",
            DateCreated = DateTime.UtcNow,
        },
        new Item 
        { 
            Id = Guid.NewGuid(),
            Name = "Item two",
            Description = "This is item two",
            DateCreated = DateTime.UtcNow,
        },
        new Item 
        { 
            Id = Guid.NewGuid(),
            Name = "Item three",
            Description = "This is item three",
            DateCreated = DateTime.UtcNow,
        },
        new Item 
        { 
            Id = Guid.NewGuid(),
            Name = "Item four",
            Description = "This is item four",
            DateCreated = DateTime.UtcNow,
        }
    };

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(TodoDbContext));
            services.AddDbContext<TodoDbContext>((container, options) =>
            {
                options.UseSqlite("DataSource=:memory:");
            });

            using (var dbContext = services.BuildServiceProvider().GetRequiredService<TodoDbContext>())
            {
                dbContext.AddRange(Items);
                dbContext.SaveChanges();
            }
        });

        builder.UseEnvironment("Development");
    }
}
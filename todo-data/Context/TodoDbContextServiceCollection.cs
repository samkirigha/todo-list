using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using todo_data.Context;

namespace todo_data.Context;

public static class TodoDbContextServiceCollection
{
    public static IServiceCollection AddTodoDbContext(this IServiceCollection services)
    {
        services.AddDbContext<TodoDbContext>((provider, options) =>
        {
            var configuration = provider.GetService<IConfiguration>();
            var connection = configuration?["Database"];

            options.UseSqlite(connection);
        });

        return services;
    }
}
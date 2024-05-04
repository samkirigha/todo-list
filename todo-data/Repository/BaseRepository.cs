using Microsoft.Extensions.DependencyInjection;
using Todo.Interfaces.Repository;

namespace todo_data.Repository;

public static class BaseRepositoryServiceCollection
{
    public static IServiceCollection AddBaseRepository(this IServiceCollection services)
    {
        services.AddScoped<IItemRepository, ItemRepository>();
        
        return services;
    }
}
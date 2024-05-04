
using Microsoft.Extensions.DependencyInjection;
using Todo.Interfaces.Services;
using todo_core;

namespace todo_services;

public static class BaseServiceCollection
{
    public static IServiceCollection AddBaseService(this IServiceCollection services)
    {
        services.AddScoped<IItemService, ItemService>();
        
        return services;
    }
}
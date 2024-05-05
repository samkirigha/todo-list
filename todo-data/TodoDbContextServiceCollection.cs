using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Interfaces.Repository;
using todo_data.Repository;

namespace todo_data.Context;

public static class TodoDbContextServiceCollection
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
	{        
		// Repositories
		services.AddScoped<IItemRepository, ItemRepository>();

		return services;
	}
}
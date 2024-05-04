using Microsoft.EntityFrameworkCore;
using todo_data.Configuration;
using Todo.Models;

namespace todo_data.Context;

public class TodoDbContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.ApplyConfiguration(new ItemConfiguration());
    }
}
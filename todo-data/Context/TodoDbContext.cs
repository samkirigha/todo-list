using Microsoft.EntityFrameworkCore;
using todo_data.Configuration;
using Todo.Models;

namespace todo_data.Context;

public class TodoDbContext(DbContextOptions<TodoDbContext> options) : DbContext(options)
{
    // item
    public virtual DbSet<Item> Items { get; set; }
    
    // ********** OnModelCreating **********
    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{		
		// item
		modelBuilder.ApplyConfiguration(new ItemConfiguration());
	}

}
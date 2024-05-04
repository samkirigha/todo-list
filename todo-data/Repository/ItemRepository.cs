using Microsoft.EntityFrameworkCore;
using Todo.Interfaces.Repository;
using Todo.Models;
using todo_data.Context;

namespace todo_data.Repository;

public class ItemRepository : IItemRepository
{
    private readonly TodoDbContext _dbContext;

    public ItemRepository(TodoDbContext context)
        => _dbContext = context;

    public IQueryable<Item> GetItemList()
        => _dbContext.Items.AsNoTracking();
    
    public async Task<Item?> GetItemDetails(Guid id)
        => await _dbContext.Items.FindAsync(id);
    
    public async Task<Item> AddItem(Item item)
    {
        item.DateCreated = DateTime.UtcNow;
        
        await _dbContext.Items.AddAsync(item);
        await _dbContext.SaveChangesAsync();
        
        return item;
    }

    public async Task UpdateItem(Guid id, Item item)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            await _dbContext.Items
                .Where(x => x.Id.Equals(id))
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(x => x.Name, item.Name)
                    .SetProperty(x => x.DateModified, DateTime.UtcNow));

            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task DeleteItem(Guid id)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            await _dbContext.Items
                .Where(x => x.Id.Equals(id))
                .ExecuteDeleteAsync();
                
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
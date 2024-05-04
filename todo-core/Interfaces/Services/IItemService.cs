

using Todo.Models;

namespace Todo.Interfaces.Services;

public interface IItemService
{
    List<Item> GetItemList();
    Task<Item?> GetItemDetails(Guid id);
    Task<Item> AddItem(Item item);
    Task UpdateItem(Guid id, Item item);
    Task DeleteItem(Guid id);
    int CalculateFactorial(int number);
}
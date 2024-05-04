using System.Text;
using System.Text.Json;
using Todo.Interfaces.Repository;
using Todo.Interfaces.Services;
using Todo.Models;

namespace todo_core;

public class ItemService : IItemService
{
    private readonly IItemRepository _repository;

    public ItemService(IItemRepository repository)
        => _repository = repository;

    public List<Item> GetItemList()
        => _repository.GetItemList().ToList();

    public async Task<Item?> GetItemDetails(Guid id)
        => await _repository.GetItemDetails(id);

    public async Task<Item> AddItem(Item item)
        => await _repository.AddItem(item);

    public async Task UpdateItem(Guid id, Item item)
        => await _repository.UpdateItem(id, item);

    public async Task DeleteItem(Guid id)
        => await _repository.DeleteItem(id);

    public int CalculateFactorial(int number)
    {
        var factorial = Enumerable
            .Range(1, number)
            .Aggregate(1, (factorial, number) => factorial * number);

        return factorial;
    }
}
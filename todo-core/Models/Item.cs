
namespace Todo.Models;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}
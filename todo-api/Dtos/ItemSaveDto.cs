using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Todo.Models;

namespace todo_api.Dtos;

public record ItemSaveDto
{
    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    public Item ToEntity() => new Item { Name = Name, Description = Description };
}
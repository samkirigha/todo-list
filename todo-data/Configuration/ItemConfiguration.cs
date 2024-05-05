using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Models;

namespace todo_data.Configuration;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> entity)
    {
        entity.ToTable("Items");
        entity.HasKey(e => e.Id).HasName("Id");
        entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
        entity.Property(e => e.Description).HasColumnName("Description").HasMaxLength(500).IsRequired();
        entity.Property(e => e.DateCreated).HasColumnName("DateCreated");
        entity.Property(e => e.DateModified).HasColumnName("DateModified");
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Infrastructure.Persistence.Configuration;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("items");

        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).HasColumnName("id").HasDefaultValueSql("UUID_GENERATE_V4()");

        builder.Property(i => i.UserId).HasColumnName("user_id").IsRequired();

        builder.Property(i => i.CreatedAt).HasColumnName("created_at").HasColumnType("TIMESTAMPTZ")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(i => i.UpdatedAt).HasColumnName("updated_at").HasColumnType("TIMESTAMPTZ")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(i => i.Title).HasColumnName("title").IsRequired().HasMaxLength(256);

        builder.Property(i => i.Description).HasColumnName("description").HasColumnType("TEXT");

        builder.Property(i => i.IsCompleted).HasColumnName("is_completed").IsRequired().HasDefaultValue(false);

        builder.Property(i => i.DueDate).HasColumnName("due_date").HasColumnType("TIMESTAMPTZ");

        builder.HasIndex(i => i.UserId);

        builder.HasOne(i => i.User).WithMany().HasForeignKey(i => i.UserId);
    }
}
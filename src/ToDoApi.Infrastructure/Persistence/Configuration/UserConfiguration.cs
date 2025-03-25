using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApi.ToDoApi.Domain.Model;

namespace ToDoApi.ToDoApi.Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("id").HasDefaultValueSql("UUID_GENERATE_V4()");

        builder.Property(u => u.Email).HasColumnName("email").IsRequired().HasMaxLength(256);
        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.Password).HasColumnName("password").IsRequired().HasColumnType("TEXT");

        builder.Property(u => u.Name).HasColumnName("name").IsRequired().HasMaxLength(128);

        builder.Property(u => u.LastName).HasColumnName("last_name").IsRequired().HasMaxLength(128);

        builder.Property(u => u.CreatedAt).HasColumnName("created_at").HasColumnType("TIMESTAMPTZ")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(u => u.UpdatedAt).HasColumnName("updated_at").HasColumnType("TIMESTAMPTZ")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}
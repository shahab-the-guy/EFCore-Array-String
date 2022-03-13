using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.EFCore.ArrayPrimitiveTypes.Domain;
using Sample.EFCore.ArrayPrimitiveTypes.Storage.Converters;

namespace Sample.EFCore.ArrayPrimitiveTypes.Storage.Configurations;
public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToContainer("Books");

        builder.HasKey(p => p.Id);
        builder.HasPartitionKey(p => p.Id);
        builder.Property(p => p.Id)
            .ToJsonProperty("id")
            .IsRequired();

        builder.Property(p => p.Name).IsRequired();

        builder.Property(p => p.Tags)
            .HasConversion<TagsValueConverter>();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.EFCore.ArrayPrimitiveTypes.Domain;

namespace Sample.EFCore.ArrayPrimitiveTypes.Storage.Configurations;

public sealed class DraftConfiguration : IEntityTypeConfiguration<Draft>
{
    public void Configure(EntityTypeBuilder<Draft> builder)
    {
        builder.ToContainer("Drafts").HasNoDiscriminator();

        builder.HasKey(p => new {p.Id, p.Owner});
        builder.Property(p => p.Id)
            .ToJsonProperty("id")
            .IsRequired();
        
        builder.HasPartitionKey(p => p.Owner);
        builder.Property(p => p.Owner).IsRequired();

        builder.Property(p=>p.Type).IsRequired();
    }
}

using Microsoft.EntityFrameworkCore;
using Sample.EFCore.ArrayPrimitiveTypes.Domain;
using Sample.EFCore.ArrayPrimitiveTypes.Storage.Configurations;

namespace Sample.EFCore.ArrayPrimitiveTypes.Storage;

public sealed class BooksContext : DbContext
{
    public BooksContext(DbContextOptions<BooksContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new DraftConfiguration());
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Draft> Drafts { get; set; }
}

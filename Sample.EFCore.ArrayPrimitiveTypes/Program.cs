// See https://aka.ms/new-console-template for more information

using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sample.EFCore.ArrayPrimitiveTypes.Configurations;
using Sample.EFCore.ArrayPrimitiveTypes.Storage;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile("appsettings.Development.json", true, true)
    .Build();

var dbConfig = new DatabaseConfiguration();
configuration.Bind("CosmosDB", dbConfig);

var dbContextOptionsBuilder = new DbContextOptionsBuilder<BooksContext>();
dbContextOptionsBuilder
    .EnableDetailedErrors()
    .EnableSensitiveDataLogging()
    .LogTo(Console.WriteLine)
    .UseCosmos(dbConfig.Account, dbConfig.AccountKey, dbConfig.Database,
        builder => builder.ConnectionMode(ConnectionMode.Gateway));

var context = new BooksContext(dbContextOptionsBuilder.Options);

// await context.Drafts.AddRangeAsync(new[]
// {
//     new Draft(Guid.Parse("4042662c-3b7a-4970-aee5-8bdc6d5e7d1d"), "Sample", 1),
//     new Draft(Guid.NewGuid(), "Sample", 2),
//     new Draft(Guid.NewGuid(), "Sample", 3),
//     new Draft(Guid.NewGuid(), "Draft", 1),
//     new Draft(Guid.NewGuid(), "Draft", 2),
// });
// await context.SaveChangesAsync();

var c = context.Drafts.FindAsync(Guid.Parse("4042662c-3b7a-4970-aee5-8bdc6d5e7d1d"), "Sample");

Console.WriteLine("Hooray!");

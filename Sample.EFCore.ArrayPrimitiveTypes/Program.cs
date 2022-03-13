// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sample.EFCore.ArrayPrimitiveTypes.Configurations;
using Sample.EFCore.ArrayPrimitiveTypes.Domain;
using Sample.EFCore.ArrayPrimitiveTypes.Storage;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json" , false, true)
    .Build();

var dbConfig = new DatabaseConfiguration();
configuration.Bind("CosmosDB" , dbConfig);

var dbContextOptionsBuilder = new DbContextOptionsBuilder<BooksContext>();
dbContextOptionsBuilder.UseCosmos(dbConfig.Account, dbConfig.AccountKey, dbConfig.Database);
var dbContext = new BooksContext(dbContextOptionsBuilder.Options);

var book = new Book("Domain Driven Design");
book.AddTag("domain", "design");
dbContext.Books.Add(book);
await dbContext.SaveChangesAsync(CancellationToken.None);


var newContext = new BooksContext(dbContextOptionsBuilder.Options);
var fetchedFromDbBook = await newContext.Books.FirstOrDefaultAsync();
Console.WriteLine(string.Join("," , fetchedFromDbBook!.Tags));

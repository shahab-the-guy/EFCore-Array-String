namespace Sample.EFCore.ArrayPrimitiveTypes.Configurations;
public sealed class DatabaseConfiguration
{
    public string Account { get; init; }
    public string AccountKey { get; init; }
    public string Database { get; init; }

    public override string ToString() => $"Account: {Account} - Database: {Database}";
}

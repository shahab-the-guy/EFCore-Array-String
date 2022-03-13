using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace Sample.EFCore.ArrayPrimitiveTypes.Storage.Converters;

public class TagsValueConverter : ValueConverter<IReadOnlyCollection<string>, string[]>
{
    public TagsValueConverter() : base(
        value => value.ToArray(),
        dbValue => dbValue.ToList())
    {
    }
}

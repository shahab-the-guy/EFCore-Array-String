namespace Sample.EFCore.ArrayPrimitiveTypes.Domain;

public sealed class Book
{
    private List<string> _tags;

    private Book()
    {
        _tags = new List<string>();
    }
    public Book(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        _tags = new List<string>();
    }
    
    public Guid Id { get; }
    public string Name { get; }
    public IReadOnlyCollection<string> Tags => _tags.AsReadOnly();

    public void AddTag(params string[] tags) => _tags = new List<string>(_tags.Union(tags));
}

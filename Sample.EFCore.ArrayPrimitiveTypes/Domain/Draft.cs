namespace Sample.EFCore.ArrayPrimitiveTypes.Domain;

public sealed class Draft
{
    public Guid Id { get; set; }
    public string Owner { get; set; }

    public int Type { get; set; }

    public Draft(Guid id, string owner, int type)
    {
        Id = id;
        Owner = owner;
        Type = type;
    }
}

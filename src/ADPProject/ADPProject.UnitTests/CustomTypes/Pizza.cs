namespace ADPProject.Tests.CustomTypes;

public class Pizza : IComparable<Pizza>
{
    public string Name { get; init; }
    public int NumberOfSlices { get; init; }

    public int CompareTo(Pizza? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
        if (nameComparison != 0) return nameComparison;
        return NumberOfSlices.CompareTo(other.NumberOfSlices);
    }
}
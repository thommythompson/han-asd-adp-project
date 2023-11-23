namespace ADPProject.Tests.CustomTypes;

public class PizzaOrder : IComparable<PizzaOrder>
{
    public int OrderNo { get; init; }
    public Pizza Pizza { get; init; }

    public int CompareTo(PizzaOrder? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var orderNoComparison = OrderNo.CompareTo(other.OrderNo);
        if (orderNoComparison != 0) return orderNoComparison;
        return Pizza.CompareTo(other.Pizza);
    }
}
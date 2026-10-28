namespace RefactoringPlayground.Models;

public enum CustomerTier
{
    Standard,
    Silver,
    Gold,
    Platinum,
}

public enum OrderStatus
{
    Pending,
    Paid,
    Shipped,
    Delivered,
    Cancelled,
}

public class Address
{
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
}

public class Customer
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public CustomerTier Tier { get; set; }
    public Address? Address { get; set; }
    public List<Order>? Orders { get; set; }
}

public class OrderLine
{
    public string Sku { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
    public Customer? Customer { get; set; }
    public List<OrderLine> Lines { get; set; } = [];
    public decimal Total { get; set; }
}

public abstract record Shape;

public sealed record Circle(double Radius) : Shape;

public sealed record Rectangle(double Width, double Height) : Shape;

public sealed record Triangle(double Base, double Height) : Shape;

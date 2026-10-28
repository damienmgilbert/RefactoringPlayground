namespace RefactoringPlayground.CodeStyle.Members;

public interface IOrderRepository
{
    Order? Find(int id);
}

public interface INotifier
{
    void Notify(string message);
}

// REFACTOR [IDE0290]: Use primary constructor (the two ctor assignments become primary-constructor parameters)
public class OrderProcessor
{
    private readonly IOrderRepository _repository;
    private readonly INotifier _notifier;

    public OrderProcessor(IOrderRepository repository, INotifier notifier)
    {
        _repository = repository;
        _notifier = notifier;
    }

    public bool Cancel(int id)
    {
        var order = _repository.Find(id);
        if (order == null)
        {
            return false;
        }

        order.Status = OrderStatus.Cancelled;

        // REFACTOR [refactoring]: Convert to interpolated string
        _notifier.Notify("Order " + order.Id + " cancelled");
        return true;
    }
}

public class Product
{
    private string _sku = string.Empty;
    private decimal _price;

    // REFACTOR [IDE0044]: Make field readonly (it is never reassigned)
    private int _reorderLevel = 10;

    // REFACTOR [IDE0021]: Use expression body for constructor
    public Product(string sku)
    {
        Sku = sku;
    }

    // REFACTOR [IDE0032]: Use auto property ('public string Sku { get; set; } = string.Empty;')
    public string Sku
    {
        get { return _sku; }
        set { _sku = value; }
    }

    // REFACTOR [IDE0032] (C# 14): convert the backing field to the 'field' keyword
    public decimal Price
    {
        get { return _price; }
        set
        {
            if (value < 0m)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            _price = value;
        }
    }

    // REFACTOR [IDE0025 / IDE0027]: Use expression body for property / accessor
    public int ReorderLevel
    {
        get { return _reorderLevel; }
    }

    // REFACTOR [IDE0022]: Use expression body for method
    public bool NeedsReorder(int stock)
    {
        return stock < _reorderLevel;
    }
}

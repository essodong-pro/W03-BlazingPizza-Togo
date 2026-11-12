namespace BlazingPizza;

public sealed record Pizza(int Id, string Name, string Description, decimal Price, string Category, string Emoji, string ArtClass, string? Badge = null);
public sealed record CartItem(Pizza Pizza, int Quantity);

public static class PizzaMenu
{
    public static readonly IReadOnlyList<Pizza> All =
    [
        new(1, "Margherita", "San Marzano tomato, creamy mozzarella, fresh basil", 6500m, "Vegetarian", "🍅", "art-tomato", "THE CLASSIC"),
        new(2, "Garden Party", "Roasted peppers, red onion, mushrooms, olives", 7500m, "Vegetarian", "🫑", "art-green", "GARDEN FRESH"),
        new(3, "Pepperoni Heat", "Spiced pepperoni, mozzarella, honey-chili finish", 8500m, "Spicy", "🌶️", "art-red", "A LITTLE KICK"),
        new(4, "The Smokehouse", "Smoky beef, caramelized onion, barbecue sauce", 9500m, "Meaty", "🥓", "art-orange", "FAN FAVORITE"),
        new(5, "Mushroom Melt", "Brown butter mushrooms, garlic, mozzarella, thyme", 8000m, "Vegetarian", "🍄", "art-lilac"),
        new(6, "Double Trouble", "Pepperoni, smoky beef, sausage, extra mozzarella", 10500m, "Meaty", "🥓", "art-gold", "EXTRA LOADED")
    ];
}

public sealed class CartState
{
    private readonly Dictionary<int, CartItem> _items = [];
    public event Action? Changed;
    public IReadOnlyCollection<CartItem> Items => _items.Values;
    public int ItemCount => _items.Values.Sum(item => item.Quantity);
    public decimal Subtotal => _items.Values.Sum(item => item.Pizza.Price * item.Quantity);

    public void Add(Pizza pizza)
    {
        _items[pizza.Id] = _items.TryGetValue(pizza.Id, out var item)
            ? item with { Quantity = item.Quantity + 1 }
            : new CartItem(pizza, 1);
        Changed?.Invoke();
    }

    public void RemoveOne(int pizzaId)
    {
        if (!_items.TryGetValue(pizzaId, out var item)) return;
        if (item.Quantity <= 1) _items.Remove(pizzaId);
        else _items[pizzaId] = item with { Quantity = item.Quantity - 1 };
        Changed?.Invoke();
    }

    public void Clear() { _items.Clear(); Changed?.Invoke(); }
}

public static class PriceFormatter
{
    private static readonly System.Globalization.CultureInfo Togo = System.Globalization.CultureInfo.GetCultureInfo("fr-TG");
    public static string Format(decimal amount) => $"{amount.ToString("N0", Togo)} FCFA";
}

namespace KodaStore.Api.Models;

public sealed class Products
{
    public string ProductCode {get; private set;}
    public string Name {get; private set;}
    public decimal Price {get; private set;}
    public int Stock {get; private set;}
    public string Category {get; private set;}

    public Products(string productCode, string name, decimal price, int stock, string category)
    {
        if (string.IsNullOrWhiteSpace(productCode))
        {
            throw new ArgumentException("Product is required", nameof(productCode));
        }
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("name is required", nameof(name));
        }
        if (price < 0)
        {
            throw new ArgumentOutOfRangeException("Price not negative", nameof(price));
        }
        if (stock < 0)
        {
            throw new ArgumentOutOfRangeException("stock not negative", nameof(stock));
        }
        if (string.IsNullOrWhiteSpace(category))
        {
            throw new ArgumentException("category is required", nameof(category));
        }

        ProductCode = productCode;
        Name = name;
        Price = price;
        Stock = stock;
        Category = category.Trim();
    }

    public void UpdateDetail(string name, decimal price, int stock, string category)
    {
        var validate = new Products(ProductCode, name, price, stock, category);

        Name = validate.Name;
        Price = validate.Price;
        Stock = validate.Stock;
        Category = validate.Category;
    }
}
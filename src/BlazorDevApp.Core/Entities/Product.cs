using Ardalis.GuardClauses;

using BlazorDevApp.Core.Interfaces;

namespace BlazorDevApp.Core.Entities;
public class Product : EntityBase, IAggregateRoot
{
    public Product(string name, string description, decimal price) : base()
    {
        Guard.Against.NullOrEmpty(name, nameof(name));
        Guard.Against.NullOrEmpty(description, nameof(description));
        Guard.Against.NegativeOrZero(price, nameof(price));

        Name = name;
        Description = description;
        Price = price;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }

    public void Update(string name, string description, decimal price)
    {
        Guard.Against.NullOrEmpty(name, nameof(name));
        Guard.Against.NullOrEmpty(description, nameof(description));
        Guard.Against.NegativeOrZero(price, nameof(price));

        Name = name;
        Description = description;
        Price = price;

        base.Update();
    }
}

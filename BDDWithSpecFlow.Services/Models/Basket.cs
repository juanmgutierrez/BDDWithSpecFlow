namespace BDDWithSpecFlow.Services.Models;

public class Basket
{
    public User User { get; set; }

    public Basket(User user)
    {
        User = user;
    }

    public List<Product> Products { get; } = new();
    public decimal TotalAmount { get; set; } = 0;
    public decimal Subtotal { get; set; } = 0;
    public decimal Taxes { get; set; } = 0;

    public void AddProduct(Product product)
    {
        Products.Add(product);
        Subtotal = PricingService.CalculateSubtotalForBasket(this);
        Taxes = PricingService.CalculateTaxesForBasket(this);
        TotalAmount = PricingService.CalculateTotalAmountForBasket(this);
    }
}

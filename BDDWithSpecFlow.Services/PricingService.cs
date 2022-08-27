using BDDWithSpecFlow.Services.Models;

namespace BDDWithSpecFlow.Services;

public class PricingService
{
    private const decimal FinalConsumerTax = (decimal)0.21;

    public static decimal CalculateSubtotalForBasket(Basket basket) => basket.Products.Sum(p => p.Price);

    public static decimal CalculateTaxesForBasket(Basket basket)
    {
        if (basket.User.IsFinalConsumer)
            return basket.Subtotal * FinalConsumerTax;
        else
            throw new NotImplementedException();
    }

    public static decimal CalculateTotalAmountForBasket(Basket basket) => CalculateSubtotalForBasket(basket) + CalculateTaxesForBasket(basket);
}

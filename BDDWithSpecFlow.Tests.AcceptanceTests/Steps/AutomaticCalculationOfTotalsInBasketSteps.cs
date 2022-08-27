using BDDWithSpecFlow.Services.Models;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BDDWithSpecFlow.Tests.AcceptanceTests.Steps
{
    [Binding]
    public class AutomaticCalculationOfTotalsInBasketSteps
    {
        private User _user;
        private Basket _basket;

        [Given(@"a user registered as final consumer")]
        public void GivenAUserRegisteredAsFinalConsumer()
        {
            _user = new()
            {
                IsFinalConsumer = true
            };
        }

        [Given(@"an empty basket")]
        public void GivenAnEmptyBasket()
        {
            _basket = new(_user);
        }

        [When(@"a (.*) costing \$(.*) is added to the basket")]
        public void WhenALaptopCostingIsAddedToTheBasket(string productName, decimal price)
        {
            _basket.AddProduct(new Product(productName, price));
        }

        [Then(@"the basket subtotal should be \$(.*)")]
        public void ThenTheBasketSubtotalShouldBe(decimal subtotal)
        {
            _basket.Subtotal.Should().Be(subtotal);
        }

        [Then(@"the basket taxes should be \$(.*)")]
        public void ThenTheBasketTaxesShouldBe(decimal taxes)
        {
            _basket.Taxes.Should().Be(taxes);
        }

        [Then(@"the basket total amount should be \$(.*)")]
        public void ThenTheBasketTotalAmountShouldBe(decimal totalAmount)
        {
            _basket.TotalAmount.Should().Be(totalAmount);
        }
    }
}

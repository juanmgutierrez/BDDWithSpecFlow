Feature: Automatic Calculation of Totals in Basket

Every Basket should have its own taxes added automatically to the total amount,
and every time a product is added it should recalculate the total amount for the basket (and the taxes)

@basket
@basketTotalAmount
Scenario: Final consumers should pay 21% of IVA (national tax)
	Given a user registered as final consumer
	And an empty basket
	When a laptop costing $1000 is added to the basket
	Then the basket subtotal should be $1000
	And the basket taxes should be $210
	And the basket total amount should be $1210
Feature: TrendyolRemoveFromBasket

Remove produckt of basket on trendyol
Scenario: RemoveToBasket
	Given A product must be added to cart
	Given the url where we are going for is trendyol sepet
	Given I close the pop up
	When click to remove basket
	Then I verify prodcut is remove to basket
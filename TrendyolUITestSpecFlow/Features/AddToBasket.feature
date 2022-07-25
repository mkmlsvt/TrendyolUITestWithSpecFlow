Feature: TrendyolAddToBasket

Scenario: AddToBasket
	Given the url where we are going for is trendyol
	Given the searching word is monster
	Given I go to product page
	When click to add basket
	Then I verify prodcut is addet to basket
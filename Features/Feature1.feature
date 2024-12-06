Feature: Feature1

A short summary of the feature

Scenario: Reset test data
	When I reset the test data
	Then the response message should be "Success"

Scenario: Buy a quantity of each fuel
	Given I get the types of fuel
	When I buy 3 quantities of each fuel
	Then all orders are added to the orders list

Scenario: Get orders created before current date
	When I get all orders
	Then I can get the number of orders created before today

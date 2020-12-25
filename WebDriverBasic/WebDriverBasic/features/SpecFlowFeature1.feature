Feature: TestProduct
	As a user 
	I want to log into the website
	So I want to create a product

Scenario: Create a product
	Given I open "http://localhost:5000" url
	When I log into with username "user" and password "user" 
	And I click on send button
	Then I should be at the home page
	When I click on the all products 
	And I click on create new product
	And I create a product with fields "My_product", "Produce", "Mayumi's", "1000", 10, 500, 4, 1
	And I click on send button product
	Then The form of creation disappeared
	And The product should be on all products page 
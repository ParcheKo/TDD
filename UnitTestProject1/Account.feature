Feature: Account


@mytag
Scenario: Create Account in Valid Status
	Given I want Create an account with balance 10000
	When I Create account 
	Then the account status must be 'Active' and balance must be 10000

Feature: Registration
	

@mytag
Scenario: Nop Commerce Registration
	Given I have Nop Commerce Application Launched
	And I launch Registration Page
	When I submitt the Registration Page
	Then I could be Registered Successfully

Scenario: Nop Commerce Registration and Login
	Given I have Nop Commerce Application Launched
	And I launch Registration Page
	When I submitt the Registration Page
	Then I could be Registered Successfully
	When I Launch Login Page
	And I give user credentials
	Then I should be logged in successfully
	And I Should Logout

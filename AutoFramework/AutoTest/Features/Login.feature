Feature: Login
	Verify Login functionality works fine with different set of positive data

@Smoke
Scenario: Login to the EA App
	Given I navigate to EA App url and I see Welcome page is loaded
	When i click login link
	Then I can see login Page
	When I enter userName and Password
	| userName | Password |
	| admin    | password |
	And I click login button
	Then I should see user is logged in
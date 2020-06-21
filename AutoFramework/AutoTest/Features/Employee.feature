Feature: Employee
	Verify Add Delete and Update Functionality of Employee

@Smoke
Scenario: Create Employee with Valid Data
	Given I navigate to EA App url and I see Welcome page is loaded
	When i click login link
	Then I can see login Page
	When I enter userName and Password
	| userName | Password |
	| admin    | password |
	And I click login button
	When i click employeelist link
	And I click createnew button
	When i enter following details
	| Name    | Salary | DurationWorked | Grade | Email   |
	| vaibhav | 2000   | 12             | 1     | v@g.com |
	And I click create button
	Then i can see Employee is added


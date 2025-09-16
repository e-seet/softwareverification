Feature: UsingCalculatorDivision
	In order to conquer divisions
	As a division enthusiast
	I want to understand a variety of division operations

	@Division
	Scenario: Divide two numbers
		Given I have a calculator
		When I have entered 20 and 4 into the calculator and press divide
		Then the result should be 5

	@Division
	Scenario: Divide by zero should throw exception
		Given I have a calculator
		When I have entered 10 and 0 into the calculator and press divide
		Then the result should throw an exception

	# lab 2.1  Qn 9
	@Divisions
	Scenario: Dividing two numbers
		Given I have a calculator
		When I have entered 1 and 2 into the calculator and press divide
		Then the division result should be 0.5
	@Divisions
	Scenario: Dividing zero by a number
		Given I have a calculator
		When I have entered 0 and 15 into the calculator and press divide
		Then the division result should be 0
	@Divisions
	Scenario: Dividing by zeros
		Given I have a calculator
		When I have entered 15 and 0 into the calculator and press divide
		Then the division result equals positive_infinity
	@Divisions
	Scenario: Dividing by zero by zero
		Given I have a calculator
		When I have entered 0 and 0 into the calculator and press divide
		Then the division result should be 1

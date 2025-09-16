Feature: UsingCalculatorDefectDensity
  In order to calculate defect density
  As a system quality engineer
  I want to be able to calculate the defect density of a system

@DefectDensity
Scenario: Calculate defect density
  Given I have a calculator
  When I have entered 50 and 1000 into the calculator and press defect density
  Then the defect density result should be 0.05

@DefectDensity
Scenario: Calculate defect density with zero software size should throw exception
  Given I have a calculator
  When I have entered 50 and 0 into the calculator and press defect density
  Then the result should throw an exception


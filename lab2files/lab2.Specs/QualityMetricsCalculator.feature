Feature: Quality Metrics Calculator
  In order to perform system quality assessments
  As a system quality engineer
  I want to calculate defect density and track Shipped Source Instructions across system releases
  So that I can assess software quality and monitor code evolution

  Background:
    Given I have a calculator

  @QualityAssessment
  Scenario: Calculate defect density for a software system
    When I have entered 25 and 5000 into the calculator and press defect density
    Then the defect density result should be 0.005

  @QualityAssessment
  Scenario: Calculate defect density with zero system size should throw exception
    When I have entered 25 and 0 into the calculator and press defect density
    Then the defect density result should throw an exception

  @QualityAssessment
  Scenario: Calculate defect density with high defect count
    When I have entered 100 and 2000 into the calculator and press defect density
    Then the defect density result should be 0.05

  @CodeEvolution
  Scenario: Calculate new total SSI for second release
    When I have entered 1000, 300, 200, and 100 into the calculator and press SSI
    Then the SSI result should be 1400

  @CodeEvolution
  Scenario: Calculate new total SSI with no new code
    When I have entered 1000, 0, 150, and 50 into the calculator and press SSI
    Then the SSI result should be 1100

  @CodeEvolution
  Scenario: Calculate new total SSI with more deletions than additions
    When I have entered 1000, 100, 50, and 300 into the calculator and press SSI
    Then the SSI result should be 850

  @CodeEvolution
  Scenario: Calculate new total SSI for third release
    When I have entered 1400, 200, 100, and 150 into the calculator and press SSI
    Then the SSI result should be 1550

Feature: Software Quality Engineering Calculator
  In order to perform software quality and reliability analysis
  As a software quality engineer
  I want to be able to calculate various software quality metrics and reliability measures
  So that I can assess software quality, predict reliability, and make informed decisions about software development and maintenance

  Background:
    Given I have a calculator

  @QualityMetrics
  Scenario: Calculate defect density for software system
    When I have entered 50 and 1000 into the calculator and press defect density
    Then the defect density result should be 0.05

  @QualityMetrics
  Scenario: Calculate defect density with zero software size should throw exception
    When I have entered 50 and 0 into the calculator and press defect density
    Then the defect density result should throw an exception

  @ReliabilityMetrics
  Scenario: Calculate Mean Time Between Failures (MTBF)
    When I have entered 1000 and 5 into the calculator and press MTBF
    Then the availability result should be 200

  @ReliabilityMetrics
  Scenario: Calculate system availability
    When I have entered 950 and 1000 into the calculator and press Availability
    Then the availability result should be 0.95

  @ReliabilityMetrics
  Scenario: Calculate MTBF with zero failures should throw exception
    When I have entered 1000 and 0 into the calculator and press MTBF
    Then the availability result should throw an exception

  @ReliabilityMetrics
  Scenario: Calculate availability with zero total time should throw exception
    When I have entered 950 and 0 into the calculator and press Availability
    Then the availability result should throw an exception

  @CodeMetrics
  Scenario: Calculate Shipped Source Instructions for second release
    When I have entered 1000, 200, 150, and 50 into the calculator and press SSI
    Then the SSI result should be 1300

  @CodeMetrics
  Scenario: Calculate SSI with no new code
    When I have entered 1000, 0, 100, and 50 into the calculator and press SSI
    Then the SSI result should be 1050

  @CodeMetrics
  Scenario: Calculate SSI with more deleted than added code
    When I have entered 1000, 50, 25, and 200 into the calculator and press SSI
    Then the SSI result should be 875

  @ReliabilityModeling
  Scenario: Calculate current failure intensity using Basic Musa model
    When I have entered 10, 0.1, and 5 into the calculator and press failure intensity
    Then the failure intensity result should be approximately 6.07

  @ReliabilityModeling
  Scenario: Calculate average number of expected failures using Basic Musa model
    When I have entered 10, 0.1, and 5 into the calculator and press expected failures
    Then the expected failures result should be approximately 39.35

  @ReliabilityModeling
  Scenario: Calculate failure intensity with zero time
    When I have entered 10, 0.1, and 0 into the calculator and press failure intensity
    Then the failure intensity result should be 10

  @ReliabilityModeling
  Scenario: Calculate expected failures with zero time
    When I have entered 10, 0.1, and 0 into the calculator and press expected failures
    Then the expected failures result should be 0

# Lab 3: CI/CD and Test Automation

This lab demonstrates Continuous Integration/Continuous Deployment (CI/CD) practices and automated testing using SpecFlow.

## Project Structure

```
Lab3/
├── Lab3/                    # Main application
│   ├── Calculator.cs        # Calculator implementation
│   └── Lab3.csproj         # Project file
├── Lab3.Specs/             # SpecFlow test project
│   ├── Calculator.feature  # Gherkin feature file
│   ├── CalculatorSteps.cs  # Step definitions
│   ├── Hooks.cs           # Dependency injection setup
│   └── Lab3.Specs.csproj  # Test project file
├── .github/workflows/      # CI/CD pipeline
│   └── ci.yml             # GitHub Actions workflow
└── Lab3.sln               # Solution file
```

## Features Implemented

### Calculator Operations
- Addition
- Subtraction
- Multiplication
- Division (with zero-division handling)
- Power calculation
- Square root (with negative number handling)
- Factorial calculation

### Test Automation
- **SpecFlow Integration**: BDD-style testing with Gherkin scenarios
- **Comprehensive Test Coverage**: All calculator operations tested
- **Exception Handling Tests**: Edge cases and error conditions
- **Dependency Injection**: Proper setup using SpecFlow hooks

### CI/CD Pipeline Features

#### 1. Build and Test
- Automatic build on push/PR
- Unit test execution
- Test result reporting
- Code coverage collection

#### 2. Security Scanning
- SARIF-based security analysis
- Vulnerability detection
- Security best practices enforcement

#### 3. Code Quality
- SonarCloud integration
- Code quality metrics
- Technical debt analysis
- Code smell detection

#### 4. Deployment Pipeline
- Staging deployment
- Integration testing
- Production deployment (on main branch)
- Environment-specific configurations

## Running the Tests

### Local Development
```bash
# Restore dependencies
dotnet restore

# Build the solution
dotnet build

# Run all tests
dotnet test

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"
```

### SpecFlow Tests
```bash
# Run SpecFlow tests specifically
dotnet test Lab3.Specs/Lab3.Specs.csproj

# Generate test reports
dotnet test --logger "trx;LogFileName=test-results.trx"
```

## CI/CD Pipeline Triggers

- **Push to main/develop**: Full pipeline execution
- **Pull Request**: Build, test, and quality checks
- **Main branch**: Includes deployment to production

## Test Scenarios Covered

1. **Basic Operations**
   - Addition, subtraction, multiplication, division
   - Power and square root calculations
   - Factorial computation

2. **Edge Cases**
   - Division by zero
   - Negative number square roots
   - Negative factorial inputs
   - Large number handling

3. **Exception Handling**
   - Proper exception throwing
   - Meaningful error messages
   - Graceful error handling

## Best Practices Demonstrated

### Testing
- **BDD Approach**: Business-readable test scenarios
- **Test Isolation**: Each test is independent
- **Comprehensive Coverage**: Happy path and edge cases
- **Clear Assertions**: Meaningful test failures

### CI/CD
- **Fast Feedback**: Quick build and test cycles
- **Quality Gates**: Security and quality checks
- **Automated Deployment**: Consistent deployment process
- **Environment Separation**: Staging and production environments

### Code Quality
- **Dependency Injection**: Loose coupling and testability
- **Error Handling**: Proper exception management
- **Code Organization**: Clear separation of concerns
- **Documentation**: Self-documenting code and tests

## Dependencies

- **.NET 8.0**: Target framework
- **SpecFlow 3.9.74**: BDD testing framework
- **NUnit 3.14.0**: Test framework
- **Coverlet**: Code coverage collection
- **GitHub Actions**: CI/CD platform

## Getting Started

1. Clone the repository
2. Restore dependencies: `dotnet restore`
3. Build the solution: `dotnet build`
4. Run tests: `dotnet test`
5. View test results and coverage reports

## Continuous Integration Benefits

- **Early Bug Detection**: Issues caught in development
- **Consistent Quality**: Automated quality checks
- **Fast Feedback**: Immediate test results
- **Deployment Confidence**: Automated testing before deployment
- **Team Collaboration**: Shared quality standards

# Lab 4: Testing with Dependencies and Mocking

This lab demonstrates advanced testing techniques including dependency injection, mocking, and different types of test doubles.

## Project Structure

```
Lab4/
├── Lab4/                           # Main application
│   ├── Interfaces/                # Interface definitions
│   │   ├── ILogger.cs            # Logging interface
│   │   ├── IEmailService.cs      # Email service interface
│   │   └── IAccountRepository.cs # Data access interface
│   ├── Services/                  # Business logic
│   │   └── BankingService.cs     # Main banking service
│   └── Lab4.csproj               # Project file
├── Lab4.Tests/                    # Test project
│   ├── BankingServiceTests.cs    # Unit tests with mocking
│   ├── TestDoublesDemo.cs        # Test doubles demonstration
│   └── Lab4.Tests.csproj         # Test project file
└── Lab4.sln                       # Solution file
```

## Key Concepts Demonstrated

### 1. Dependency Injection
- **Constructor Injection**: Dependencies injected through constructor
- **Interface Segregation**: Small, focused interfaces
- **Inversion of Control**: High-level modules don't depend on low-level modules

### 2. Test Doubles
- **Stub**: Provides predefined responses to method calls
- **Mock**: Verifies interactions and behavior
- **Fake**: Provides a working implementation for testing
- **Spy**: Records interactions for later verification

### 3. Mocking with Moq
- **Setup**: Configure mock behavior
- **Verify**: Assert method calls and parameters
- **Times**: Verify call frequency
- **It.IsAny**: Flexible parameter matching

## Banking Service Features

### Core Operations
- **Money Transfer**: Transfer funds between accounts
- **Balance Inquiry**: Get account balance
- **Deposit**: Add money to account
- **Email Notifications**: Send transaction notifications

### Dependencies
- **IAccountRepository**: Data access layer
- **IEmailService**: External email service
- **ILogger**: Logging functionality

## Test Scenarios

### 1. Successful Operations
```csharp
[Fact]
public void TransferMoney_SuccessfulTransfer_ReturnsTrue()
{
    // Arrange: Setup mocks with expected behavior
    // Act: Execute the operation
    // Assert: Verify result and interactions
}
```

### 2. Error Handling
```csharp
[Fact]
public void TransferMoney_InsufficientFunds_ReturnsFalse()
{
    // Test business rule validation
    // Verify proper error logging
    // Ensure no side effects
}
```

### 3. External Service Failures
```csharp
[Fact]
public void TransferMoney_EmailServiceUnavailable_StillCompletesTransfer()
{
    // Test resilience to external failures
    // Verify core functionality still works
    // Check appropriate logging
}
```

## Test Doubles Examples

### Stub Example
```csharp
// Provides predefined responses
var stubRepository = new Mock<IAccountRepository>();
stubRepository.Setup(x => x.GetAccount(1)).Returns(testAccount);
// Focus: Return values, not interactions
```

### Mock Example
```csharp
// Verifies interactions
var mockLogger = new Mock<ILogger>();
// ... setup and act ...
mockLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
// Focus: Behavior verification
```

### Fake Example
```csharp
// Working implementation for testing
public class FakeAccountRepository : IAccountRepository
{
    private Dictionary<int, Account> _accounts = new();
    // Real implementation for testing
}
```

## Best Practices Demonstrated

### 1. Test Organization
- **Arrange-Act-Assert**: Clear test structure
- **Single Responsibility**: One test, one scenario
- **Descriptive Names**: Clear test intent
- **Independent Tests**: No test dependencies

### 2. Mocking Best Practices
- **Mock External Dependencies**: Don't mock the system under test
- **Verify Important Interactions**: Don't over-verify
- **Use Setup for Behavior**: Configure expected responses
- **Verify Critical Paths**: Ensure important calls happen

### 3. Dependency Injection Benefits
- **Testability**: Easy to inject test doubles
- **Flexibility**: Can swap implementations
- **Loose Coupling**: Dependencies are abstracted
- **Single Responsibility**: Each class has one reason to change

## Running the Tests

### Prerequisites
```bash
# Install .NET 8.0 SDK
# Restore packages
dotnet restore
```

### Test Execution
```bash
# Run all tests
dotnet test

# Run with detailed output
dotnet test --verbosity normal

# Run specific test class
dotnet test --filter "BankingServiceTests"

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## Mocking Scenarios Covered

### 1. Successful Operations
- Money transfer with email notifications
- Balance retrieval with logging
- Deposit with confirmation email

### 2. Business Rule Violations
- Insufficient funds
- Invalid amounts
- Non-existent accounts

### 3. External Service Failures
- Email service unavailable
- Database connection issues
- Network timeouts

### 4. Exception Handling
- Proper exception propagation
- Error logging
- Graceful degradation

## Advanced Testing Techniques

### 1. Parameter Verification
```csharp
mockEmailService.Verify(x => x.SendEmail(
    "user@example.com",
    "Transfer Notification",
    It.Is<string>(body => body.Contains("$100"))
), Times.Once);
```

### 2. Callback Verification
```csharp
mockLogger.Setup(x => x.Log(It.IsAny<string>()))
    .Callback<string>(message => logMessages.Add(message));
```

### 3. Sequence Verification
```csharp
var sequence = new MockSequence();
mockRepository.InSequence(sequence).Setup(x => x.AccountExists(1)).Returns(true);
mockRepository.InSequence(sequence).Setup(x => x.GetAccount(1)).Returns(account);
```

## Benefits of This Approach

### 1. Testability
- **Isolated Testing**: Test business logic without external dependencies
- **Fast Tests**: No database or network calls
- **Reliable Tests**: No flaky tests due to external services

### 2. Maintainability
- **Clear Dependencies**: Explicit dependency requirements
- **Easy Refactoring**: Change implementations without breaking tests
- **Documentation**: Tests serve as living documentation

### 3. Quality Assurance
- **Comprehensive Coverage**: Test all code paths
- **Edge Case Testing**: Handle error conditions
- **Integration Testing**: Verify component interactions

## Dependencies

- **.NET 8.0**: Target framework
- **xUnit**: Test framework
- **Moq 4.20.72**: Mocking framework
- **Microsoft.NET.Test.Sdk**: Test SDK

## Key Takeaways

1. **Dependency Injection** enables testable, maintainable code
2. **Mocking** allows testing in isolation
3. **Test Doubles** serve different purposes in testing
4. **Proper Setup** is crucial for effective mocking
5. **Verification** ensures expected behavior
6. **Error Scenarios** are as important as happy paths

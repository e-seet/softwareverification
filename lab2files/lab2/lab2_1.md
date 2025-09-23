 Requirements 13-18: Context Injection and 
 
Requirements 13-18:
Context Injection: All step definition classes share the same Calculator instance
Division Feature: Handles edge cases like 0/0 and division by zero
Factorial Feature: Calculates factorials including zero factorial and handles negative numbers
Availability Feature: Calculates MTBF and Availability with proper error handling
Basic Musa Model: Implements failure intensity and expected failures calculations


 Feature Development

 # Test Division feature specifically
dotnet test --filter "FullyQualifiedName~Division" --verbosity normal

# Test Factorial feature specifically  
dotnet test --filter "FullyQualifiedName~Factorial" --verbosity normal

# Test Availability feature specifically
dotnet test --filter "FullyQualifiedName~Availability" --verbosity normal

# Test Basic Reliability feature specifically
dotnet test --filter "FullyQualifiedName~BasicReliability" --verbosity normal


Requirement 16: Factorial Feature Scenarios
✅ Normal factorial calculation:
Scenario: "Calculate factorial of a positive number" (5! = 120)
✅ Zero factorial:
Scenario: "Calculate factorial of zero" (0! = 1)
✅ Additional scenarios (beyond the minimum requirement):
Scenario: "Calculate factorial of one" (1! = 1)
Scenario: "Calculate factorial of negative number should throw exception" (-3! throws exception)
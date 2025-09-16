1. Basic Test Commands
dotnet test

Run Tests with Verbose Output:
dotnet test --verbosity normal

Run Tests for Specific Project:
dotnet test lab2.Specs/lab2.Specs.csproj

2. Run Tests by Feature/Tag

Run Tests by Tag:
# Run only Addition tests
dotnet test --filter "Category=Addition"

# Run only Division tests  
dotnet test --filter "Category=Division"

# Run only Factorial tests
dotnet test --filter "Category=Factorial"

Run Tests by Feature Name:
# Run only Calculator feature tests
dotnet test --filter "FullyQualifiedName~Calculator"

# Run only Availability feature tests
dotnet test --filter "FullyQualifiedName~Availability"

>Build and Run Commands Summary
# Build entire solution
dotnet build

# Build specific project
dotnet build lab2.Specs/lab2.Specs.csproj

# Clean and rebuild
dotnet clean && dotnet build

Test Commands:
# Run all tests
dotnet test

# Run with detailed output
dotnet test --verbosity normal

# Run specific project
dotnet test lab2.Specs/lab2.Specs.csproj

# Run by tag
dotnet test --filter "Category=Addition"

# Run by feature name
dotnet test --filter "FullyQualifiedName~Calculator"


Test Commands That Don't Work (Due to Ambiguity):
# All of these fail with the same error:
dotnet test                                    # All tests
dotnet test --filter "Category=Addition"      # By tag
dotnet test --filter "FullyQualifiedName~AddTwoNumbers"  # By scenario
dotnet test --filter "FullyQualifiedName~Calculator"     # By feature


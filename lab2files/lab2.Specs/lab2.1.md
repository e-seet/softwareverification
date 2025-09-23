Run all test dotnet test --filter "FullyQualifiedName~Dividing"

Run individual test:

# Run each test individually

dotnet test --filter "FullyQualifiedName~DividingTwoNumbers" 
dotnet test --filter "FullyQualifiedName~DividingZeroByANumber" 

dotnet test --filter "FullyQualifiedName~DividingByZeros" 
dotnet test --filter "FullyQualifiedName~DividingByZeroByZero"


## This
dotnet test --filter "FullyQualifiedName~Division" --verbosity normal

 Passed DivideTwoNumbers [< 1 ms]
  Passed DividingByZeroByZero [< 1 ms]
  Passed DividingByZeros [< 1 ms]
  Passed DividingTwoNumbers [< 1 ms]
  Passed DividingZeroByANumber [< 1 ms]
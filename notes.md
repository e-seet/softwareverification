# Quick Ref

## Set up
1. Create a solution (container for everything)
dotnet new sln -n Lab1

2. Create your console app project (actual code)
dotnet new console -n Lab1

3. Add the project into the solution
dotnet sln Lab1.sln add Lab1/Lab1.csproj

## Run
dotnet run --project Lab1


## Create the SpecFlow test project
### Create a new NUnit test project (for SpecFlow to plug into)
dotnet new nunit -n Lab1.Specs

### Add it to the solution
dotnet sln Lab1.sln add Lab1.Specs/Lab1.Specs.csproj

### Add reference from tests to main project
dotnet add Lab1.Specs/Lab1.Specs.csproj reference Lab1/Lab1.csproj

## Add SpecFlow packages

cd Lab1.Specs

dotnet add package SpecFlow
dotnet add package SpecFlow.NUnit
dotnet add package SpecFlow.Tools.MsBuild.Generation

## Restore + Build
cd ..
dotnet restore
dotnet build

## Run tests (your .feature files)
dotnet test


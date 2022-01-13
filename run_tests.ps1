# Run the automated tests
Set-Location .\Src\Tests\AutomationExample.Tests\
dotnet build --configuration Debug --source .\AutomationExample.Tests.sln --source ..\..\..\Nuget\nuget.config
dotnet test .\AutomationExample.Tests.sln

Set-Location ..\..\..

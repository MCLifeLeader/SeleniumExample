# Run the automated tests
Set-Location .\Src\Tests\AutomationExample.Tests\
dotnet build --configuration Debug --source .\AutomationExample.Tests.sln
dotnet test .\AutomationExample.Tests.sln

Set-Location ..\..\..

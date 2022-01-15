# Setup dotnet test run argument
[string] $loggerArgument = '\"trx;logfilename=Test_Results.' + (Get-Date).ToString("yyyyMMdd.HHmmss") + '.trx\"'

# Run the automated tests
Set-Location .\Src\Tests\AutomationExample.Tests\
dotnet build --configuration Debug --source .\AutomationExample.Tests.sln --source ..\..\..\Nuget\nuget.config
dotnet test .\AutomationExample.Tests.sln --logger $loggerArgument #--collect:"Code Coverage"

Set-Location ..\..\..

# Build the AutomationExample.WebApi project
Set-Location .\Src\Docker\AutomationExample.WebApi\ 
dotnet build --configuration Release --source .\AutomationExample.WebApi.sln --source ..\..\..\Nuget\nuget.config
docker build -f ".\AutomationExample.WebApi\Dockerfile" --force-rm -t automationexamplewebapi  --label "com.microsoft.created-by=visual-studio" --label "com.microsoft.visual-studio.project-name=AutomationExample.WebApi" ".\"

# Build the AutomationExample.WebApp project
Set-Location ..\AutomationExample.WebApp\
dotnet build --configuration Release --source .\AutomationExample.WebApp.sln --source ..\..\..\Nuget\nuget.config
docker build -f ".\AutomationExample.WebApp\Dockerfile" --force-rm -t automationexamplewebapp  --label "com.microsoft.created-by=visual-studio" --label "com.microsoft.visual-studio.project-name=AutomationExample.WebApp" ".\"

Set-Location ..\..\..
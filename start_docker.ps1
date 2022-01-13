# Run the AutomationExample.WebApi container
Start-Process -FilePath 'docker' -ArgumentList 'run -it -p 46080:80 -p 46443:443 --name AutomationExampleApi automationexamplewebapi:latest'

# Run the AutomationExample.WebApp container
Start-Process -FilePath 'docker' -ArgumentList 'run -it -p 47080:80 -p 47443:443 --name AutomationExampleApp automationexamplewebapp:latest'
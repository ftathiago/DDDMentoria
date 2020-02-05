#!/bin/sh

XML_DIR="../.artifacts/Coverage/"
REPORT_DIR="../.artifacts/Report/"
HISTORY_DIR="../.artifacts/History/"

#docker run -d --name sonarqube -p 9000:9000 sonarqube

sudo rm $XML_DIR -rf
sudo rm $REPORT_DIR -rf

dotnet tool install --global -sonarscanner --version 4.8.0
dotnet test "../Venda.Dominio.Test/Venda.Dominio.Test.csproj" /p:CollectCoverage=true  /p:CoverletOutputFormat=opencover 
dotnet test "../Venda.Application.Test/Venda.Application.Test.csproj" /p:CollectCoverage=true  /p:CoverletOutputFormat=opencover


#dotnet sonarscanner begin /k:"DDDMentoria" /d:sonar.host.url=http://localhost:9000 /d:sonar.cs.opencover.reportsPaths="**/coverage.opencover.xml" /d:sonar.coverage.exclusions="**Test.cs"
dotnet sonarscanner begin /k:"DDDMentoria" /d:sonar.host.url=http://localhost:9000 /d:sonar.login=admin /d:sonar.password=admin
dotnet build "../DDDMentoria.sln"
dotnet sonarscanner end /d:sonar.login=admin /d:sonar.password=admin

#!/bin/sh

XML_DIR="../.artifacts/Coverage/"
REPORT_DIR="../.artifacts/Report/"
HISTORY_DIR="../.artifacts/History/"

#docker run -d --name sonarqube -p 9000:9000 sonarqube

sudo rm $XML_DIR -rf
sudo rm $REPORT_DIR -rf
dotnet tool install -sonarscanner
dotnet sonarscanner begin /k:"DDDMentoria" /d:sonar.host.url=http://localhost:9000
#sudo dotnet clean "../DDDMentoria.sln"
dotnet clean
dotnet build "../DDDMentoria.sln"
dotnet test "../Venda.Dominio.Test/Venda.Dominio.Test.csproj" /p:CollectCoverage=true  /p:CoverletOutputFormat=opencover 
dotnet test "../Venda.Application.Test/Venda.Application.Test.csproj" /p:CollectCoverage=true  /p:CoverletOutputFormat=opencover
dotnet sonarscanner end

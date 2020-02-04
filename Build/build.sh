#!/bin/sh

XML_DIR="../.artifacts/Coverage/"
REPORT_DIR="../.artifacts/Report/"
HISTORY_DIR="../.artifacts/History/"

docker run -d --name sonarqube -p 9000:9000 sonarqube

sudo rm $XML_DIR -rf
sudo rm $REPORT_DIR -rf

dotnet sonarscanner begin /k:"DDDMentoria" /d:sonar.host.url=http://localhost:9000 
sudo dotnet clean "../DDDMentoria.sln"
sudo dotnet build "../DDDMentoria.sln"
sudo dotnet test "../Venda.Dominio.Test/Venda.Dominio.Test.csproj" /p:CollectCoverage=true /p:CoverletOutput=$XML_DIR /p:CoverletOutputFormat=cobertura /p:CoverletOutput="${XML_DIR}Venda.Dominio.Test.xml" /p:Exclude='[xunit.*]*'
sudo dotnet test "../Venda.Application.Test/Venda.Application.Test.csproj" /p:CollectCoverage=true /p:CoverletOutput=$XML_DIR /p:CoverletOutputFormat=cobertura /p:CoverletOutput="${XML_DIR}Venda.Application.Test.xml" /p:Exclude='[xunit.*]*'
dotnet sonarscanner end
sudo ./tools/reportgenerator -reports:"${XML_DIR}*.xml" -targetdir:$REPORT_DIR -reporttypes:"HTML;HTMLSummary" -historydir:$HISTORY_DIR
#!/bin/sh

XML_DIR="../.artifacts/Coverage/"
REPORT_DIR="../.artifacts/Report/"
HISTORY_DIR="../.artifacts/History/"
PROJECT_SLN = '../DDDMentoria.sln'

sudo rm $XML_DIR -rf
sudo rm $REPORT_DIR -rf

dotnet clean $PROJECT_SLN
dotnet build $PROJECT_SLN
dotnet test "../Venda.Dominio.Test/Venda.Dominio.Test.csproj" /p:CollectCoverage=true /p:CoverletOutput=$XML_DIR /p:CoverletOutputFormat=cobertura /p:CoverletOutput="${XML_DIR}Venda.Dominio.Test.xml" /p:Exclude='[xunit.*]*'
dotnet test "../Venda.Application.Test/Venda.Application.Test.csproj" /p:CollectCoverage=true /p:CoverletOutput=$XML_DIR /p:CoverletOutputFormat=cobertura /p:CoverletOutput="${XML_DIR}Venda.Application.Test.xml" /p:Exclude='[xunit.*]*'
sudo ./tools/reportgenerator -reports:"${XML_DIR}*.xml" -targetdir:$REPORT_DIR -reporttypes:"HTML;HTMLSummary" -historydir:$HISTORY_DIR
#!/bin/sh

XML_DIR="../../.artifacts/Coverage/"
REPORT_DIR="./.artifacts/Report/"
HISTORY_DIR="./.artifacts/History/"
PROJECT_SLN='DDDMentoria.sln'

sudo rm $XML_DIR -rf
sudo rm $REPORT_DIR -rf

dotnet tool install dotnet-reportgenerator-globaltool --tool-path tools

dotnet clean 
dotnet build 
dotnet test /p:CollectCoverage=true /p:CoverletOutput=$XML_DIR /p:CoverletOutputFormat=cobertura /p:CoverletOutput="${XML_DIR}Venda.Dominio.Test.xml" /p:Exclude='[xunit.*]*'
sudo ./tools/reportgenerator -reports:".artifacts/Coverage/*.xml" -targetdir:$REPORT_DIR -reporttypes:"HTML;HTMLSummary" -historydir:$HISTORY_DIR
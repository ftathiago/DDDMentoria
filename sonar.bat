dotnet tool install --global dotnet-sonarscanner --version 4.8.0
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
dotnet sonarscanner begin /k:"DDDMentoria" /d:sonar.host.url=http://192.168.100.106:9000 /d:sonar.login=admin /d:sonar.password=admin
dotnet build "DDDMentoria.sln"
dotnet sonarscanner end /d:sonar.login=admin /d:sonar.password=admin
pause
@echo off

SET src=./Src
SET pub=../../Publish
echo *src:%src%                  
echo *publish: %pub% 
echo.

::PackageVersion overrides csproj <Version>100.0.0</Version></PropertyGroup>
dotnet pack %src%/Na.Extentions/Na.Extentions.csproj -c Release  -o %pub% /p:PackageVersion=1.0.0
dotnet pack %src%/Na.ConsoleHelper/Na.ConsoleHelper.csproj -c Release  -o %pub% /p:PackageVersion=1.0.0
dotnet pack %src%/Na.TextConfig/Na.TextConfig.csproj -c Release  -o %pub% /p:PackageVersion=1.0.0

start Publish
::Pause
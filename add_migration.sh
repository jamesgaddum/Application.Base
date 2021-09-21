#!/bin/bash

cd "$(dirname "$0")"
cd "Application.Base.Persistence"

echo "Migration Name:"
read migrationName

startupProject=""
PS3='Startup Project: '
options=("WebAPI" "Application.Tests")
select opt in "${options[@]}"
do
    case $opt in
        "WebAPI")
            startupProject="../Application.Base.WebAPI/Application.Base.WebAPI.csproj"
            break
            ;;
        "Application.Tests")
            startupProject="../Application.Base.Application.Tests/Application.Base.Application.Tests.csproj"
            break
            ;;
        *) echo "invalid option $REPLY";;
    esac
done

dotnet ef migrations add $migrationName --startup-project $startupProject

../run_migration.sh $startupProject

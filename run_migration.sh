#!/bin/bash

echo "Apply Migration (Y/n):"
read applyMigration

if [ $applyMigration == "Y" ]
then
    dotnet ef database update --startup-project $1
fi

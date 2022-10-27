#!/usr/bin/env bash

# This script creates the proper directory structure for an algorithm and data
# structures assignment.

if [ ! $# -eq 2 ]; then
    echo "Usage: $0 <sheetid> <exampleid>" >&2
    exit 1
fi

if [ $( echo -n "$1" | wc -c ) -eq 1 ]; then
    SHEET_ID="0$1"
else
    SHEET_ID="$1"
fi

if [ $( echo -n "$2" | wc -c ) -eq 1 ]; then
    EXAMPLE_ID="0$2"
else
    EXAMPLE_ID="$2"
fi

SHEET_PATH="einheit$SHEET_ID"
EXAMPLE_PATH="beispiel$EXAMPLE_ID"

if [ ! -d "$SHEET_PATH" ]; then
    mkdir "$SHEET_PATH"
fi

if [ ! -d "$SHEET_PATH/$EXAMPLE_PATH" ]; then
    mkdir "$SHEET_PATH/$EXAMPLE_PATH"
fi

cd "$SHEET_PATH/$EXAMPLE_PATH"

if [ ! -f *.csproj ]; then
    dotnet new console --framework net5.0
fi

if [ ! -f .gitignore ]; then
    echo "bin/" > .gitignore
    echo "obj/" >> .gitignore
fi

if [ ! -f .gitignore ]; then

cat <<EOF > README.md
# Code für das Blatt $SHEET_ID, Beispiel $EXAMPLE_ID

Mit Linux geht alles von ganz alleine.
EOF

fi


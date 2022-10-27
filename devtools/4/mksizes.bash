#!/usr/bin/env bash

if [ $# eq 0]; then
    echo "Usage: $0 <list of files>"
    exit 1
fi

for file in "${@}"; do
    for size in 350 740 1400 2800; do

        BASE_NAME=$(basename "$file" .jpg)
        OUTPUTT_NAME = "$BASE_NAME-$size""px.jpg"
        #alte schreibweise convert resize "$size""x" "$file" "$OUTPUT_NAME"

         magick "$file" -resize "$size""x" "$OUTPUT_NAME"  
    done
done

# Image Stamper

In ein Eingabefled kann man die eines Bildes am Netz eingeben.
Das Bild wird per PHP heruntergeladen und mit einem Datums-Stempel versehen.

Alle schon behandeltetn Bilder werden im Ordner images/
gespeichert und als gallery angezeigt.

Demo Seite: https://users.multimediatechnology.at/~bjelline/image-stamper/

## Installation:

Lade die [Zip-Datei](https://gitlab.mediacube.at/bjelline/wp-assignments-public/-/jobs/artifacts/master/raw/image-stamper.zip?job=zip) herunter und entpacke sie in deinem Webspace. Der Ordner soll `image-stamper/` heissen.

Der Source Code enthält die Dateien `composer.json` und `composer.lock` - daran
erkennt man, dass hier php packages verwendet werden, die erst installiert werden müssen.

Sonderaufgabe Sommersemester 2022: lösche `composer.lock`.

Auf der Kommandozeile: gehe in den Ordner und starte `composer install` um die pakete zu installieren.

Für das Speichern der Bilder im Ordner `images` braucht es noch die
richtigen Zugriffsrechte für diesen Ordner.

## Installation in Deinem Webspace auf users.multimediatechnology.at

Installiere das Programm auch in Deinem Websapce. Teste ob es funktioniert.



## Fragen 

Gib die Antworten  in der `README.md` im Ordner `5` deines "Software Development Tools" Repositories ab:

* was ist die URL Deiner Version des image-stamper in Deinem Webspace auf  users.multimediatechnology.at?
https://users.multimediatechnology.at/~fhs47843/image-stamper/index.php

Lies die Datei  `composer.json` den Code des PHP Programms.  
* Welche Pakete wurden in composer.json angegeben?
guzzlehttp
imagine




* Welche Pakete wurden installiert?
psr
composor
symfony
ralouphie
guzzlehttp
imagine

* In welchem Ordner findest Du die installierten Pakete?
/vendor


* Wozu werden die Pakete im PHP-Code verwendet?
imagine : edits the picture
GuzzleHttp: sends http requests
psr : give statuses to things the file is working on
composor : tool for dependency management 
symfony: Component Library
ralouphie : needed for getallheaders.php


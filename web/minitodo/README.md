# Ein Javascript-Programm durchschauen und ändern
Diese Übung ist wieder eine Einzelübung.

## Setup

- [zip-datei](https://gitlab.mediacube.at/bjelline/wp-assignments-public/-/jobs/artifacts/master/raw/minitodo.zip?job=zip) herunterladen, entpacken und den entpackten Ordner in den eigenen, lokalen Gitlab-Repository Ordner `minitodo` verschieben.
- Stylsheet und JavaScript Datei in der `index.html` einbinden.

## Fragen beantworten

Beantworte folgende Fragen **direkt hier im README.md** des `minitodo`-Ordners:

1. Welche Datenstrukturen werden im Javascript Programm verwendet? string, const, numberm, class, function

2. Welche Events werden verwendet? (Welche Aktion löst das Event aus? Wo werden die Events festgelegt, wo abgearbeitet?)

   wenn man enter drückt und was eingegeben hat
   wenn man das feld angreuzt
   wenn man auf das x drückt
   wenn man mit einem doppel click editiert

   > **Beispiel-Antwort**: Wenn das event "splot" am html-tag \<button> auftritt wird die funktion do_splot() aufgerufen.

3. Wie gelangt ein neue eingetippter Text in die Todo-Liste?
mit einem Onclickevent beim tippen von "ENTER"

4. Wie werden die "Delete"-Buttons dargestellt?
<button></button>
5. Was wird genau im localStorage abgespeichert? Bleiben dabei alle Javascript Datentypen erhalten?
daten die kein expiration date hat wie cookies
Local Storage speichert alles in eun utf-16 Domstring und ales wir convertiert

6. Wenn man HTML-Code eingibt: wird der als HTML-Code in die Seite eingebaut? Oder escaped? Wo geschieht das? Ja, er wird eingebaut im Onclick Event wo die daten eingelesen wird

## Änderungen vornehmen

Nimm folgende Änderungen vor:

1. Die Überschrift und der Footer soll deinen Namen enthalten, also z.B: "Todos von Andrea"

2. Die "Delete"-Buttons sollen immer sichtbar sein.

### Optional (viel Arbeit) 2 Zusatzpunkte

- Zu jedem Todo-Item soll auch ein Datum mit gespeichert werden.

- Die Todo-Items sollen nach Datum sortiert angezeigt werden


## Checkliste
- [ ] Einbinden von css und js-File in `index.html`
- [ ] Beantwortung der Fragen in diesem `README.md`
- [ ] Name in Überschrift und Footer
- [ ] Delete Button wird immer angezeigt
- [ ] **Zusatz** (1 Punkt): zu neuen Todos wird ein Datum dazugespeichert
- [ ] **Zusatz** (1 Punkt): Todos werden nach Datum sortiert.
- [ ] Und wie immer gilt: HTML Validator wirft keine Fehler und wir bauen nur Seiten mit einer validen HTML Struktur. Nochmal zur Wiederholung: Seitenquelltext jeder Seite in den HTML Validator schmeißen (https://validator.w3.org/#validate_by_input), dann funktioniert es auch mit PHP Dateien. **Achtung: HTML Validator Fehler bzgl. style im Body (besteht auch bei Brigittes Vorlage) wird nicht als Fehler bewertet!**

## Dateiliste
Dateien, die bei dieser Aufgabe verändert oder angelegt werden:
| Datei | Abgabeort | Hinweis |
| ------ | ------ | ------ |
| index.html | Webspace und Repo, minitodo/ | JS und CSS Dateien wurden eingebunden
| README.md | Webspace und Repo, minitodo/ | Enthält die Antworten zu den Fragen
| app.js | Webspace und Repo, minitodo/ | 


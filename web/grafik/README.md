## Funktion

Wenn man auf den Stern drückt bounced der Stern von der mitte nach links.

wenn man ihn dann noch mal drauf drückt geht er von rechts  in die Mitte

and repeat

# Animiere den Stern!

Achtung, diese Übung wird im Ordner `grafik/` abgegeben!

Lade den Code als [Zip-Datei](https://gitlab.mediacube.at/bjelline/wp-assignments-public/-/jobs/artifacts/master/raw/star.zip?job=zip) herunter.

Verwende die (bereits eingebundene) Library [GreenSock Animation Platform (GSAP)](https://greensock.com), um den Stern oder die Sterne (beliebig) zu animieren (Hinweis: im Beispielcode wird der große Stern bereits ein bisschen animiert, ihr könnt die bestehende Animation dort erweitern oder eine ganz neue und andere machen).

> Tipp: schaut euch das [Getting Started with GSAP](https://greensock.com/get-started)-Video an.

Diese Übung wurde von Lisi Linhart erstellt.
- Slides dazu https://slides.com/lisilinhart/svg-animation
- CodePen unter https://codepen.io/lisilinhart/pen/mLKBMz.

## Neuer CSS Selektor

Im SVG-Code sind die einzelnen Sterne nicht mit `class` oder `id` benannt, sondern mit einem neuen attribute [`data-name` ([Using data attributes](https://developer.mozilla.org/en-US/docs/Learn/HTML/Howto/Use_data_attributes)):

      <path data-name="star-2" d="M43.4 19.5c-.3 ..." fill="#489ba9" />
      <path data-name="star-1" d="M31.4 10.5c-.2 ..." fill="#fcc14c" />

Es gibt einen eigenen CSS Selektor, mit dem man nach beliebigen Attributen und
Werten selektieren kann: der [Attribute Selektor](https://www.w3.org/TR/selectors-3/#attribute-selectors):

Die folgenden Selektoren finden alle h1-Tags, die ein title-Attribut haben (unabhängig vom Wert des zugewiesenen Wertes), bzw. alle h3-Tags, deren title-attribut "wichtig" ist.

    h1[title] { color: blue; }

    h3[title=wichtig] { color: red; }

Für unser SVG können wir also einen einzelnen Stern selektieren:

    path[data-name=star-1] { fill: red; }

Den tag-name "path" kann man auch weglassen:

    [data-name=star-1] { fill: red; }

Und dann gibt es noch einen Trick: Mit `|=`  statt des `=` findet man alle Sterne
(solange der Wert mit `star-` beginnt - beachte das Minus-Zeichen!):

    [data-name|=star] { fill: yellow; }

Die GSAP Library kann diesen CSS-Selektor als erstes Argument verwenden,
so wie im JavaScript-Code gezeigt:

    gsap.to('[data-name="center-star-fill"]' ....

## Checkliste
- [ ] Stern oder Sterne sind beliebig animiert (Animation(en) gehen über die bestehende Animation hinaus)

## Dateiliste
Dateien, die bei dieser Aufgabe verändert werden:
| Datei | Abgabeort | Hinweis |
| ------ | ------ | ------ |
| js/index.js | Webspace und Repo, grafik/ |




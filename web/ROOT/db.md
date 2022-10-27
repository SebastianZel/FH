# Teammitglieder: Viktoriia Zhuravel,  Luka Stojkovic,  Sebastian Zelnicek
DB verwendet von: Viktoriia Zhuravel

# Antwort zu (1)
    3 tabellen
    -users->decks - Informationen über Benutzer. (user kann mehrere decks haben)
        id - primary key
    -decks - Informationen über Decks mit Bewertungen und Kommentaren, die von Benutzern hinterlassen wurden. 
            Decks stehen nur den Benutzern zur Verfügung, die sie erstellt haben. 
        id - primary key
    -decks_users - Die Beziehung zwichen Users und ihren gemachten Decks.
        users_id - foreign key
        decks_id - foreign key

# Antwort zu (2)
    Die Tabelle decks_users wurde gelöscht, weil es kein n zu m Beziehung ist und so nicht gebraucht.
    Einfach user_id als foreign key in der tabelle users speichern.

 # ALTER TABLE decks ADD user_id integer REFERENCES users(id) ON DELETE CASCADE ON UPDATE CASCADE;
 # DROP TABLE user_decks;

    Schlechte Spalte Benennung. Bedeutete bisschen was anderes. 
    Es zeigt die Menge an Staub, die der Benutzer benötigt, um dieses Deck zu erstellen.
 # ALTER TABLE decks RENAME COLUMN mana_cost TO dust_cost;

# Antwort zu (3)
    -users: email, decks: deck_code, users_id

# Antwort zu (4)
   # EXPLAIN ANALYSE select * from decks where user_id = 1
   Execution Time: 0.053 ms
   Execution Time: 0.123 ms
   Execution Time: 0.142 ms

  # CREATE INDEX user_id_index ON decks (user_id);

   Execution Time: 0.039 ms
   Execution Time: 0.028 ms
   Execution Time: 0.041 ms

   Die Laufzeit hängt von der Anzahl an Zeilen in der DB ab. Wir haben hier eine Laufzeit von ungefähr 
   0.1 ms für nur 15 Spalten. Das bedeutet, dass wenn wir 1500 Zeilen haben wird es auch ungefähr 100x langsamer. 
   Durch den Index user_id_index wurde die Zeit um ein drittel verinngert.

# Antwort zu (5)

    In dieser DB verwenden wir keine Transaktionen, weil es keinen Sinn macht. Die Werte können separat 
    in diese beiden Tabellen eingefügt werden, und das wird nichts kaputt machen, und in diesem Fall 
    wird user_id in Tabelle decks mit null gefüllt.

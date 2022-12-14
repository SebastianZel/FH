-- Christiane Koch [42553]
-- Sophie Daringer [42559]

CREATE TABLE ort (plz INTEGER PRIMARY KEY, ort VARCHAR(20));
CREATE TABLE zimmertyp (zityp VARCHAR(20) PRIMARY KEY, bettenanz INTEGER, preis DECIMAL(5,2));
CREATE TABLE zimmer (zinr SERIAL PRIMARY KEY, zityp VARCHAR(20) REFERENCES zimmertyp(zityp));
CREATE TABLE gast (kunr SERIAL PRIMARY KEY, vorname VARCHAR(20), nachname VARCHAR(20), email VARCHAR(30), strasse VARCHAR(20), plz INTEGER REFERENCES ort(plz));
CREATE TABLE verpflegung (id SERIAL PRIMARY KEY, vtyp VARCHAR(20));
CREATE TABLE buchung (buchungsnr SERIAL PRIMARY KEY, anreisetag DATE, abreisetag DATE, vid INTEGER REFERENCES verpflegung(id), kundennr INTEGER REFERENCES gast(kunr));
CREATE TABLE zimmerbuchung (zinr INTEGER REFERENCES zimmer(zinr), buchungsnr INTEGER REFERENCES buchung(buchungsnr));

INSERT INTO zimmertyp VALUES ('Deluxe-Zimmer', 2, 600);
INSERT INTO zimmertyp VALUES ('Superior-Zimmer', 2, 400);
INSERT INTO zimmertyp VALUES ('Grand-Zimmer', 2, 200);
INSERT INTO zimmertyp VALUES ('Family-Zimmer', 4, 300);
INSERT INTO zimmertyp VALUES ('Single-Suite', 1, 100);
INSERT INTO zimmer VALUES (100, 'Deluxe-Zimmer');
INSERT INTO zimmer VALUES (101, 'Deluxe-Zimmer');
INSERT INTO zimmer VALUES (102, 'Superior-Zimmer');
INSERT INTO zimmer VALUES (103, 'Superior-Zimmer');
INSERT INTO zimmer VALUES (104, 'Grand-Zimmer');
INSERT INTO zimmer VALUES (105, 'Grand-Zimmer');
INSERT INTO zimmer VALUES (200, 'Grand-Zimmer');
INSERT INTO zimmer VALUES (201, 'Grand-Zimmer');
INSERT INTO zimmer VALUES (202, 'Family-Zimmer');
INSERT INTO zimmer VALUES (203, 'Family-Zimmer');
INSERT INTO zimmer VALUES (204, 'Single-Suite');
INSERT INTO zimmer VALUES (205, 'Single-Suite');
INSERT INTO verpflegung VALUES (1, 'Frühstück');
INSERT INTO verpflegung VALUES (2, 'Halbpension');
INSERT INTO verpflegung VALUES (3, 'Vollpension');
INSERT INTO ort VALUES (5020, 'Salzburg');
INSERT INTO ort VALUES (8530, 'Deutschlandsberg');
INSERT INTO ort VALUES (1020, 'Wien');
INSERT INTO ort VALUES (5101, 'Bergheim');
INSERT INTO ort VALUES (4020, 'Linz');
INSERT INTO gast VALUES (1000, 'Tanja', 'Müller', 'tanja.mueller@gmx.at', 'Sulb 10', 8530);
INSERT INTO gast VALUES (1001, 'Hermann', 'Maier', 'h.maier@gmail.com', 'Wallensteinstraße 27', 1020);
INSERT INTO gast VALUES (1002, 'Jana', 'Bauer', 'jana.bauer@yahoo.de', 'Goethestraße 53', 4020);
INSERT INTO gast VALUES (1003, 'Sophie', 'Daringer', 'sophie.daringer@gmail.com', 'Siggerwiesen 9', 5101);
INSERT INTO gast VALUES (1004, 'Christiane', 'Koch', 'christiane.koch1@gmx.at', 'Plainstraße 85', 5020);
INSERT INTO buchung VALUES (19001, '2021-02-01', '2021-02-04', 2, 1000);
INSERT INTO zimmerbuchung VALUES (102, 19001);
INSERT INTO buchung VALUES (19002, '2021-02-01', '2021-02-04', 2, 1002);
INSERT INTO zimmerbuchung VALUES (101, 19002);
INSERT INTO buchung VALUES (19003, '2021-02-03', '2021-02-05', 3, 1001);
INSERT INTO zimmerbuchung VALUES (105, 19003);
INSERT INTO zimmerbuchung VALUES (204, 19003);
INSERT INTO buchung VALUES (19004, '2021-03-01', '2021-03-04', 1, 1000);
INSERT INTO zimmerbuchung VALUES (101, 19004);
INSERT INTO buchung VALUES (19005, '2021-03-12', '2021-03-17', 2, 1003);
INSERT INTO zimmerbuchung VALUES (104, 19005);
INSERT INTO buchung VALUES (19006, '2021-05-20', '2021-05-25', 3, 1004);
INSERT INTO zimmerbuchung VALUES (200, 19006);
INSERT INTO buchung VALUES (19007, '2021-02-04', '2021-02-06', 1, 1004);
INSERT INTO zimmerbuchung VALUES (200, 19007);

-- SELECT t.zityp, t.bettenanz, z.zinr FROM zimmertyp t FULL OUTER JOIN zimmer z on z.zityp = t.zityp LEFT OUTER JOIN (SELECT zb.zinr, b.anreisetag, b.abreisetag FROM zimmerbuchung zb FULL OUTER JOIN buchung b ON b.buchungsnr = zb.buchungsnr WHERE anreisetag <= '2021-02-04' AND abreisetag >= '2021-02-05') zb ON zb.zinr = z.zinr WHERE bettenanz = 2 GROUP BY t.zityp, t.bettenanz, z.zinr HAVING MAX(zb.anreisetag) IS null AND MAX(zb.abreisetag) IS null;
-- SELECT g.kunr, g.nachname, b.anreisetag from gast g FULL OUTER JOIN buchung b ON (b.kundennr = g.kunr);
-- SELECT v.vtyp, COUNT(*) from verpflegung v LEFT OUTER JOIN buchung b ON (v.id = b.vid) GROUP BY v.vtyp;
-- SELECT * from gast ORDER BY nachname, vorname;
-- SELECT g.kunr, g.nachname, g.vorname, (b.abreisetag-b.anreisetag) AS aufenthaltsdauer from gast g FULL OUTER JOIN buchung b ON (b.kundennr = g.kunr);

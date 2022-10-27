<?php
    include "functions.php";
    $pagetitle = "Rezeption";

    $von_db = '2021-02-01';
    $bis_db = '2021-02-05';
    $von = new DateTime( $von_db );
    $bis = new DateTime( $bis_db );
    $bis = $bis->modify( '+1 day' );
    $tag_interval = DateInterval::createFromDateString('1 day');
    $tage = new DatePeriod($von, $tag_interval, $bis);
    $anz_spalten = iterator_count($tage);

    $sth = $dbh->query("SELECT * FROM zimmer");
    $zimmer = $sth->fetchall();

    $sql = "SELECT *, GREATEST(anreisetag,'$von_db') AS von_tag, LEAST(abreisetag, '$bis_db') AS bis_tag FROM zimmerbuchung NATURAL JOIN buchung NATURAL JOIN zimmer WHERE (anreisetag between '$von_db' AND '$bis_db') OR (abreisetag BETWEEN '$von_db' AND '$bis_db')";
    $sth = $dbh->query($sql);
    $zimmerbuchung = $sth->fetchall();

    $col_of_day = array();
    $row_of_zimmer = array();

    include "header.php";
?>
<style>
  div.plan {
    display: grid;
    grid-column-gap: 3px;
    grid-row-gap: 1px;
    color: black;
  }
  div.plan div {
    text-align: center;
    vertical-align: middle;
  }
  div.tag {
      background-color: #ddd;
      line-height: 40px;
  }
  div.buchung {
      background-color: pink;
      overflow: hidden;
  }
  div.buchung.abgeschn {
      background-color: #d3714a;
      border-right: 1px black dashed;
  }
  div.zimmer, div.buchung {       line-height: 40px; }
  div.typ_Deluxe-Zimmer { background-color: gold; }
  div.typ_Superior-Zimmer { background-color: pink; }
  div.typ_Grand-Zimmer { background-color: lightgray; }
  div.typ_Family-Zimmer { background-color: lightgreen; }
  div.typ_Single-Suite { background-color: lightblue; }
</style>
    <p>Belegung von
    <?php echo $day_long->format($von); ?>
    bis
    <?php echo $day_long->format($bis) ?>
    </p>

    <div class="plan" style="grid-template-columns: 2fr repeat(<?php echo $anz_spalten ?>, 1fr); grid-template-rows: repeat(<?php echo 1+count($zimmer) ?>, 40px);">
        <div>Zimmer / Tage</div>

        <!-- Alle Tage in der obersten Zeile -->
        <?php
            foreach ($tage as $index => $datum) {
                $col = $index + 2;
                $col_of_day[$day_db->format($datum)] = $col;
                echo "<div class='tag' style='grid-column: $col; grid-row: 1'> ";
                echo $day_short->format($datum);
                echo "</div>\n";
            }
        ?>

        <!-- Alle Zimmer in der linkesten Spalte -->
        <?php
            foreach( $zimmer as $index => $z ) {
                $row = $index + 2;
                $row_of_zimmer[$z->zinr] = $row;
                echo "<div style='grid-column: 1; grid-row: $row' class='zimmer typ_$z->zityp'> Zimmer ";
                echo $z->zinr;
                echo " - ";
                echo $z->zityp;
                echo "</div>\n";
            }
        ?>

        <!-- Alle Buchungen, korrekt Platziert nach Zimmer, Anreise und Abreise -->

        <?php
            foreach( $zimmerbuchung as $index => $zb ) {
                $row = $row_of_zimmer[$zb->zinr];
                $col_von = $col_of_day[$zb->von_tag];
                $col_bis = $col_of_day[$zb->bis_tag] + 1;

                if ($zb->anreisetag != $zb->von_tag ||$zb->abreisetag != $zb->bis_tag) {
                    $class="buchung abgeschn";
                } else {
                    $class="buchung typ_$zb->zityp";
                }
                echo "<div class='$class' style='grid-column: $col_von/$col_bis; grid-row: $row'>";
                echo "<a href='buchung.php?buchungsnr=$zb->buchungsnr'>Buchung $zb->buchungsnr</a> $zb->zinr von $zb->anreisetag bis $zb->abreisetag";
                echo "</div>\n";
            }
        ?>
    </div>

<?php
    include "footer.php";
?>

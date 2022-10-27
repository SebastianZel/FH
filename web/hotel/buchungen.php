<?php
    include "functions.php";
    $pagetitle = "Buchungen";

    include "header.php";
?>
    <div class="overlay">
        <?php
            $que =$dbh->query(
                "SELECT buchung.buchungsnr, anreisetag, abreisetag,
                COUNT(zimmerbuchung.buchungsnr) AS zimmerzahl
                FROM buchung
                JOIN zimmerbuchung
                ON buchung.buchungsnr=zimmerbuchung.buchungsnr
                GROUP BY buchung.buchungsnr
                ORDER BY anreisetag;"
            );
            $buchungen = $que->fetchAll();
            ?>
            <ul>
            <?php
            
            foreach($buchungen as $buchung) {
                $anreisetag = strtotime($buchung->anreisetag);
                $abreisetag = strtotime($buchung->abreisetag);
                $interval = ($abreisetag - $anreisetag)/60/60/24;

                $buchungsnr = $buchung->buchungsnr;
                $zimmerzahl = $buchung->zimmerzahl;

                echo "<li><a href=buchung.php?buchungsnr=$buchungsnr>
                Buchung $buchungsnr</a> von $anreisetag bis $abreisetag 
                ($interval Nächte, $zimmerzahl Zimmer)</li>\n";
            }
            
            ?>
            </ul>
<?php
    include "footer.php";
?>
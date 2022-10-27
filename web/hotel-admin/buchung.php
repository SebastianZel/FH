<?php
    include "functions.php";
    $buchungsnr = $_GET['buchungsnr'];
    $pagetitle = "Buchung $buchungsnr";

    include "header.php";
?>
 <div class="overlay">
        <?php
            $que =$dbh->prepare(
                "SELECT buchung.buchungsnr, anreisetag, abreisetag,
                COUNT(zimmerbuchung.buchungsnr) AS zimmerzahl
                FROM buchung
                JOIN zimmerbuchung ON buchung.buchungsnr=zimmerbuchung.buchungsnr
                WHERE buchung.buchungsnr='$buchungsnr'
                GROUP BY buchung.buchungsnr
                ORDER BY anreisetag;"
            );
            $buchung = $que->fetch();

            $anreisetag = strtotime($buchung->anreisetag);
            $abreisetag = strtotime($buchung->abreisetag);

            echo "<p>Anreisetag: $anreisetag</p>";
            echo "<p>Abreisetag: $abreisetag</p>";

           
            $interval = ($abreisetag - $anreisetag)/60/60/24;
            if($interval > 1){
                echo "<p>Das sind $interval Nächte.</p>";
            }
            else{
                echo "<p>Das sind $interval Nacht.</p>";
            }
            
            echo "<p>Diese Buchung beinhaltet $buchung->zimmerzahl Zimmer</p>";

            $que2 =$dbh->prepare(
                "SELECT buchung.buchungsnr, zimmer.zityp, zimmerbuchung.zinr, zimmertyp.preis
                FROM buchung
                JOIN (zimmerbuchung JOIN (zimmer JOIN zimmertyp ON zimmer.zityp=zimmertyp.zityp) ON zimmerbuchung.zinr=zimmer.zinr)
                ON buchung.buchungsnr=zimmerbuchung.buchungsnr
                WHERE buchung.buchungsnr='$buchungsnr'
                GROUP BY buchung.buchungsnr, zimmerbuchung.zinr, zimmer.zityp, zimmertyp.preis
                ORDER BY anreisetag;"
            );
            $zimmer = $que2->fetchAll();
            ?>
            <ul>
            <?php
            $gesamtpreis = 0;
            foreach($zimmer as $zimmer_s) {
                $zityp =$zimmer_s->zityp;
                $zinr = $zimmer_s->zinr;
                $preis = $zimmer_s->preis;
                echo "<li>Zimmer vom Typ $zityp ($zinr), $preis  € pro Nacht</li>\n";
                $gesamtpreis += $zimmer_s->preis*$interval;
            }
            ?>
            </ul>
            <?php
            echo "Gesamtpreis: $gesamtpreis €";
        ?>
    </div>

<?php
    include "footer.php";
?>
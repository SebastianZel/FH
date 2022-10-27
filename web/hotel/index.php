<?php
    include "functions.php";
    $pagetitle = "Home";
    include "header.php";
?>

    <div class="overlay">
        <p>Welches Zimmer darf es sein?</p>
        <?php
            $sth = $dbh->query("SELECT * FROM zimmertyp");

            $zimmerList = $sth -> fetchAll();
           
            foreach($zimmerList as $zimmer){
               $zityp = $zimmer->zityp;
               $bettenanz = $zimmer->bettenanz;
               $preis = $zimmer->preis;
               echo "<p><a href=zimmertyp.php?zityp=$zityp>$zityp</a> für $bettenanz Personen: $preis € pro Nacht</p>\n";
            }
            

        ?> 

       
      
    </div>

<?php
    include "footer.php";
?>

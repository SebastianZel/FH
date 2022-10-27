<?php
    include "functions.php";
    $zityp = $_GET['zityp'];
    $pagetitle = "Zimmertyp $zityp";

    include "header.php";
?>
    <style>
    body { background-image: url(<?php echo "images/$zityp-700.jpg"?>); }
    @media only screen and { body { background-image: url(<?php echo "images/$zityp-1500.jpg"?>); } }
    @media only screen and { body { background-image: url(<?php echo "images/$zityp-3000.jpg"?>); } }
    </style>

   
      <div class="overlay">
        <?php
            $que =$dbh->prepare("SELECT * FROM zimmertyp WHERE zityp='$zityp'");
            $zimmertyp = $que->fetch();
            
            echo "<p>Für $zimmertyp->bettenanz Personen</p>";
            echo "<p>$zimmertyp->preis €</p>"
        ?>
     </div>
   

<?php
    include "footer.php";
?>
